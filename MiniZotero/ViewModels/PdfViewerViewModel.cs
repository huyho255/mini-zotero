using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class PdfViewerViewModel : ViewModelBase
    {
        private static readonly IPdfService DefaultPdfService = new PdfService();
        private readonly IPdfService _pdfService;
        private readonly Action<DocumentItem> _persistReadingState;
        private DocumentItem? _activeDocument;
        private IReadOnlyList<HighlightItem> _currentHighlights = [];

        public PdfViewerViewModel()
            : this(_ => { })
        {
        }

        public PdfViewerViewModel(Action<DocumentItem> persistReadingState)
            : this(persistReadingState, DefaultPdfService)
        {
        }

        public PdfViewerViewModel(
            Action<DocumentItem> persistReadingState,
            IPdfService pdfService)
        {
            _persistReadingState = persistReadingState;
            _pdfService = pdfService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private bool _hasDocumentLoaded;

        [ObservableProperty]
        private string _documentPath = string.Empty;

        [ObservableProperty]
        private Uri? _viewerSource;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PageDisplayText))]
        private int _currentPage = 1;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ZoomDisplayText))]
        private int _zoomPercent = 120;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PageDisplayText))]
        private int _totalPages;

        [ObservableProperty]
        private string _statusText = "Ready";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsHandToolActive))]
        [NotifyPropertyChangedFor(nameof(IsSelectToolActive))]
        [NotifyPropertyChangedFor(nameof(IsHighlightToolActive))]
        private string _toolMode = "select";

        [ObservableProperty]
        private string _emptyTitle = "Select a document to view";

        [ObservableProperty]
        private string _emptyMessage = "Import a PDF file from the sidebar.";

        [ObservableProperty]
        private bool _isTwoPageLayout = false;

        [ObservableProperty]
        private string _pdfSearchText = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchResultText))]
        private int _searchResultCount;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SearchResultText))]
        private int _currentSearchResultIndex = -1;

        public bool IsEmptyViewVisible => !HasDocumentLoaded;

        public bool IsHandToolActive => ToolMode == "hand";

        public bool IsSelectToolActive => ToolMode == "select";

        public bool IsHighlightToolActive => ToolMode == "highlight";

        public string PageDisplayText => $"{CurrentPage} / {(TotalPages > 0 ? TotalPages.ToString() : "--")}";

        public string ZoomDisplayText
        {
            get => $"{ZoomPercent}%";
            set
            {
                if (int.TryParse(value.Replace("%", "").Trim(), out var percent))
                {
                    ZoomPercent = ClampZoomPercent(percent);
                    ScriptRequested?.Invoke($"window.miniZoteroPdf?.setZoom?.({ZoomPercent});");
                }
                OnPropertyChanged(nameof(ZoomDisplayText));
            }
        }

        public string SearchResultText => SearchResultCount > 0
            ? $"{CurrentSearchResultIndex + 1} / {SearchResultCount}"
            : "0 / 0";

        public event Action<string, int, IReadOnlyList<HighlightRect>>? HighlightCreated;

        public event Action<string>? ScriptRequested;

        public void LoadDocument(DocumentItem document)
        {
            _activeDocument = document;

            if (!File.Exists(document.FilePath))
            {
                DocumentPath = document.FilePath;
                StatusText = "File not found";
                EmptyTitle = document.Title;
                EmptyMessage = "The selected PDF file does not exist.";
                HasDocumentLoaded = false;
                TotalPages = 0;
                return;
            }

            DocumentPath = document.FilePath;
            CurrentPage = Math.Max(1, document.LastReadPage);
            ZoomPercent = ClampZoomPercent(document.LastZoomPercent);

            var documentKey = string.IsNullOrWhiteSpace(document.Id)
                ? Path.GetFileNameWithoutExtension(document.FilePath)
                : document.Id;

            string viewerUrl = _pdfService.CreateViewerUri(
                documentKey,
                document.FilePath,
                CurrentPage,
                ZoomPercent,
                DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            );

            ViewerSource = new Uri(viewerUrl);

            StatusText = "Document loaded";
            EmptyTitle = document.Title;
            EmptyMessage = string.Empty;
            HasDocumentLoaded = true;
        }

        public void ClearDocument()
        {
            _activeDocument = null;
            HasDocumentLoaded = false;
            DocumentPath = string.Empty;
            ViewerSource = null;
            CurrentPage = 1;
            TotalPages = 0;
            ZoomPercent = 120;
            PdfSearchText = string.Empty;
            SearchResultCount = 0;
            CurrentSearchResultIndex = -1;
            StatusText = "Ready";
            EmptyTitle = "Select a document to view";
            EmptyMessage = "Import a PDF file from the sidebar.";
        }

        public void UpdateReadingStateFromViewer(
            int pageNumber,
            int zoomPercent,
            int totalPages = 0)
        {
            CurrentPage = Math.Max(1, pageNumber);
            ZoomPercent = ClampZoomPercent(zoomPercent);

            if (totalPages > 0)
            {
                TotalPages = totalPages;
            }

            if (_activeDocument is not null &&
                (_activeDocument.LastReadPage != CurrentPage ||
                 _activeDocument.LastZoomPercent != ZoomPercent))
            {
                _activeDocument.LastReadPage = CurrentPage;
                _activeDocument.LastZoomPercent = ZoomPercent;
                _persistReadingState(_activeDocument);
            }

            StatusText = $"Page {CurrentPage}";
        }

        public void UpdateSearchState(int searchResultCount, int currentSearchResultIndex)
        {
            SearchResultCount = Math.Max(0, searchResultCount);
            CurrentSearchResultIndex = SearchResultCount > 0
                ? Math.Clamp(currentSearchResultIndex, 0, SearchResultCount - 1)
                : -1;
        }

        public void ProcessViewerMessage(string? messageBody)
        {
            if (string.IsNullOrWhiteSpace(messageBody))
            {
                return;
            }

            PdfViewerMessage? message;

            try
            {
                message = JsonSerializer.Deserialize<PdfViewerMessage>(
                    messageBody,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
            catch (JsonException)
            {
                return;
            }

            if (message is null)
            {
                return;
            }

            if (message.Type == "highlightCreated")
            {
                AddHighlightFromViewer(
                    message.Text ?? string.Empty,
                    message.PageNumber,
                    message.Rects ?? []);

                return;
            }

            UpdateReadingStateFromViewer(
                message.PageNumber,
                message.ZoomPercent,
                message.TotalPages);

            if (message.Type == "searchChanged")
            {
                UpdateSearchState(
                    message.SearchResultCount,
                    message.CurrentSearchResultIndex);
            }

            if (message.Type == "loaded")
            {
                RequestSetToolMode(ToolMode);
                SendHighlightsToViewer();
            }
        }

        public void SetHandTool()
        {
            ToolMode = "hand";
            RequestSetToolMode("hand");
        }

        public void SetSelectTool()
        {
            ToolMode = "select";
            RequestSetToolMode("select");
        }

        public void SetHighlightTool()
        {
            ToolMode = "highlight";
            RequestSetToolMode("highlight");
        }

        [RelayCommand]
        private void ToggleTwoPageLayout()
        {
            IsTwoPageLayout = !IsTwoPageLayout;
            var flagJson = IsTwoPageLayout.ToString().ToLowerInvariant();
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.setTwoPageLayout?.({flagJson});");
        }

        [RelayCommand]
        private void GoToPreviousPage()
        {
            var pageNumber = Math.Max(1, CurrentPage - 1);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.goToPage?.({pageNumber});");
        }

        [RelayCommand]
        private void GoToNextPage()
        {
            var pageNumber = TotalPages > 0
                ? Math.Min(TotalPages, CurrentPage + 1)
                : CurrentPage + 1;

            ScriptRequested?.Invoke($"window.miniZoteroPdf?.goToPage?.({pageNumber});");
        }

        [RelayCommand]
        private void ZoomIn()
        {
            ScriptRequested?.Invoke("window.miniZoteroPdf?.zoomIn?.();");
        }

        [RelayCommand]
        private void ZoomOut()
        {
            ScriptRequested?.Invoke("window.miniZoteroPdf?.zoomOut?.();");
        }

        [RelayCommand]
        private void FitWidth()
        {
            ScriptRequested?.Invoke("window.miniZoteroPdf?.fitWidth?.();");
        }

        [RelayCommand]
        private void FitPage()
        {
            ScriptRequested?.Invoke("window.miniZoteroPdf?.fitPage?.();");
        }

        [RelayCommand]
        private void SearchInPdf()
        {
            var queryJson = JsonSerializer.Serialize(PdfSearchText.Trim());
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.searchText?.({queryJson});");
        }

        [RelayCommand]
        private void GoToNextSearchResult()
        {
            ScriptRequested?.Invoke("window.miniZoteroPdf?.goToNextSearchResult?.();");
        }

        [RelayCommand]
        private void GoToPreviousSearchResult()
        {
            ScriptRequested?.Invoke("window.miniZoteroPdf?.goToPreviousSearchResult?.();");
        }

        [RelayCommand]
        private void ClearPdfSearch()
        {
            PdfSearchText = string.Empty;
            UpdateSearchState(0, -1);
            ScriptRequested?.Invoke("window.miniZoteroPdf?.clearSearch?.();");
        }

        [RelayCommand]
        private void ActivateHandTool()
        {
            SetHandTool();
        }

        [RelayCommand]
        private void ActivateSelectTool()
        {
            SetSelectTool();
        }

        [RelayCommand]
        private void ActivateHighlightTool()
        {
            SetHighlightTool();
        }

        public void AddHighlightFromViewer(
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            HighlightCreated?.Invoke(text, pageNumber, rects);
        }

        public void LoadHighlightsIntoViewer(IReadOnlyList<HighlightItem> highlights)
        {
            _currentHighlights = highlights;
            SendHighlightsToViewer();
        }

        public void SendHighlightsToViewer()
        {
            var json = JsonSerializer.Serialize(_currentHighlights);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.setHighlights?.({json});");
        }

        public void NavigateToHighlight(HighlightItem highlight)
        {
            if (string.IsNullOrWhiteSpace(highlight.Id))
            {
                return;
            }

            var idJson = JsonSerializer.Serialize(highlight.Id);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.goToHighlight?.({idJson});");
        }

        private static int ClampZoomPercent(int zoomPercent)
        {
            return Math.Clamp(zoomPercent <= 0 ? 120 : zoomPercent, 50, 400);
        }

        private void RequestSetToolMode(string toolMode)
        {
            var toolModeJson = JsonSerializer.Serialize(toolMode);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.setToolMode?.({toolModeJson});");
        }

        private sealed class PdfViewerMessage
        {
            [JsonPropertyName("type")]
            public string? Type { get; set; }

            [JsonPropertyName("pageNumber")]
            public int PageNumber { get; set; }

            [JsonPropertyName("zoomPercent")]
            public int ZoomPercent { get; set; }

            [JsonPropertyName("totalPages")]
            public int TotalPages { get; set; }

            [JsonPropertyName("searchResultCount")]
            public int SearchResultCount { get; set; }

            [JsonPropertyName("currentSearchResultIndex")]
            public int CurrentSearchResultIndex { get; set; }

            [JsonPropertyName("text")]
            public string? Text { get; set; }

            [JsonPropertyName("rects")]
            public List<HighlightRect>? Rects { get; set; }
        }
    }
}
