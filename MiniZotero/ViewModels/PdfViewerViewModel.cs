using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class PdfViewerViewModel : ViewModelBase
    {
        private static readonly PdfJsServerService PdfServer = new();
        private readonly Action<DocumentItem> _persistReadingState;
        private DocumentItem? _activeDocument;
        private IReadOnlyList<HighlightItem> _currentHighlights = [];

        public PdfViewerViewModel()
            : this(_ => { })
        {
        }

        public PdfViewerViewModel(Action<DocumentItem> persistReadingState)
        {
            _persistReadingState = persistReadingState;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private bool _hasDocumentLoaded;

        [ObservableProperty]
        private string _documentPath = string.Empty;

        [ObservableProperty]
        private Uri? _viewerSource;

        [ObservableProperty]
        private int _currentPage = 1;

        [ObservableProperty]
        private int _zoomPercent = 120;

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

        public bool IsEmptyViewVisible => !HasDocumentLoaded;

        public bool IsHandToolActive => ToolMode == "hand";

        public bool IsSelectToolActive => ToolMode == "select";

        public bool IsHighlightToolActive => ToolMode == "highlight";

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
                return;
            }

            DocumentPath = document.FilePath;
            CurrentPage = Math.Max(1, document.LastReadPage);
            ZoomPercent = ClampZoomPercent(document.LastZoomPercent);

            PdfServer.Start();

            var documentKey = string.IsNullOrWhiteSpace(document.Id)
                ? Path.GetFileNameWithoutExtension(document.FilePath)
                : document.Id;

            string viewerUrl = PdfServer.RegisterPdf(
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

        public void UpdateReadingStateFromViewer(int pageNumber, int zoomPercent)
        {
            CurrentPage = Math.Max(1, pageNumber);
            ZoomPercent = ClampZoomPercent(zoomPercent);

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

        public void SetHandTool()
        {
            ToolMode = "hand";
        }

        public void SetSelectTool()
        {
            ToolMode = "select";
        }

        public void SetHighlightTool()
        {
            ToolMode = "highlight";
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
    }
}
