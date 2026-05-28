using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class NotePreviewPanelViewModel : ViewModelBase
    {
        private readonly INoteService _noteService;
        private readonly IHighlightService _highlightService;
        private CancellationTokenSource? _saveNoteDebounce;
        private bool _isLoadingNote;
        private const int MinimumZoomPercent = 75;
        private const int MaximumZoomPercent = 200;
        private const int ZoomStepPercent = 10;
        private const double BaseNoteFontSize = 13;
        private const double BasePreviewFontSize = 12;

        public NotePreviewPanelViewModel(
            INoteService noteService,
            IHighlightService highlightService)
        {
            _noteService = noteService;
            _highlightService = highlightService;

            InitializeTableCells();
        }

        private void InitializeTableCells()
        {
            for (var row = 0; row < 10; row++)
            {
                for (var col = 0; col < 10; col++)
                {
                    TableCells.Add(new TableCellViewModel(row, col));
                }
            }
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasDocument))]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        [NotifyPropertyChangedFor(nameof(HasHighlights))]
        [NotifyPropertyChangedFor(nameof(IsHighlightEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        [ObservableProperty]
        private string _noteText = string.Empty;

        [ObservableProperty]
        private string _statusMessage = "Ready";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(NoteZoomDisplayText))]
        [NotifyPropertyChangedFor(nameof(NoteEditorFontSize))]
        private int _noteZoomPercent = 100;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(PreviewZoomDisplayText))]
        [NotifyPropertyChangedFor(nameof(PreviewFontSize))]
        private int _previewZoomPercent = 100;

        [ObservableProperty]
        private string _tableSelectorText = "Insert Table";

        public ObservableCollection<HighlightItem> Highlights { get; } = [];

        public ObservableCollection<TableCellViewModel> TableCells { get; } = [];

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public bool HasHighlights => Highlights.Count > 0;

        public bool IsHighlightEmptyViewVisible => HasDocument && !HasHighlights;

        public string NoteZoomDisplayText => $"{NoteZoomPercent}%";

        public string PreviewZoomDisplayText => $"{PreviewZoomPercent}%";

        public double NoteEditorFontSize => BaseNoteFontSize * NoteZoomPercent / 100.0;

        public double PreviewFontSize => BasePreviewFontSize * PreviewZoomPercent / 100.0;

        public event Action<HighlightItem>? HighlightSelected;

        public event Action? HighlightsChanged;

        public event Action<int, int>? TableInsertRequested;

        public void OpenDocument(DocumentItem document)
        {
            SaveActiveNoteImmediately();

            ActiveDocument = document;
            _isLoadingNote = true;

            try
            {
                NoteText = _noteService.LoadNote(document.Id);
            }
            finally
            {
                _isLoadingNote = false;
            }

            LoadHighlights(document.Id);
        }

        public void ClearDocument()
        {
            SaveActiveNoteImmediately();
            ActiveDocument = null;
            _isLoadingNote = true;

            try
            {
                NoteText = string.Empty;
            }
            finally
            {
                _isLoadingNote = false;
            }

            Highlights.Clear();
            OnPropertyChanged(nameof(HasHighlights));
            OnPropertyChanged(nameof(IsHighlightEmptyViewVisible));
            HighlightsChanged?.Invoke();
            StatusMessage = "Ready";
        }

        public void AddHighlightFromViewer(
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (ActiveDocument is null ||
                string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            var result = _highlightService.AddHighlight(
                ActiveDocument,
                text,
                pageNumber,
                rects);

            StatusMessage = result.Message;
            LoadHighlights(ActiveDocument.Id);
        }

        public OperationResult ExportActiveDocumentToMarkdown(string outputPath)
        {
            if (ActiveDocument is null)
            {
                var failure = OperationResult.Failure("Select a document before exporting.");
                StatusMessage = failure.Message;
                return failure;
            }

            SaveActiveNoteImmediately();

            var result = _noteService.ExportDocumentNotes(
                ActiveDocument,
                NoteText,
                Highlights,
                outputPath);

            StatusMessage = result.Message;
            return result;
        }

        private void LoadHighlights(string documentId)
        {
            Highlights.Clear();

            foreach (var highlight in _highlightService.LoadHighlights(documentId))
            {
                Highlights.Add(highlight);
            }

            OnPropertyChanged(nameof(HasHighlights));
            OnPropertyChanged(nameof(IsHighlightEmptyViewVisible));
            HighlightsChanged?.Invoke();
        }

        [RelayCommand]
        private void ZoomInNote()
        {
            NoteZoomPercent = Math.Min(MaximumZoomPercent, NoteZoomPercent + ZoomStepPercent);
        }

        [RelayCommand]
        private void ZoomOutNote()
        {
            NoteZoomPercent = Math.Max(MinimumZoomPercent, NoteZoomPercent - ZoomStepPercent);
        }

        [RelayCommand]
        private void ResetNoteZoom()
        {
            NoteZoomPercent = 100;
        }

        [RelayCommand]
        private void ZoomInPreview()
        {
            PreviewZoomPercent = Math.Min(MaximumZoomPercent, PreviewZoomPercent + ZoomStepPercent);
        }

        [RelayCommand]
        private void ZoomOutPreview()
        {
            PreviewZoomPercent = Math.Max(MinimumZoomPercent, PreviewZoomPercent - ZoomStepPercent);
        }

        [RelayCommand]
        private void ResetPreviewZoom()
        {
            PreviewZoomPercent = 100;
        }

        [RelayCommand]
        private void SelectHighlight(HighlightItem? highlight)
        {
            if (highlight is null)
            {
                return;
            }

            HighlightSelected?.Invoke(highlight);
        }

        [RelayCommand]
        private void DeleteHighlight(HighlightItem? highlight)
        {
            if (highlight is null || ActiveDocument is null)
            {
                return;
            }

            var result = _highlightService.DeleteHighlight(ActiveDocument.Id, highlight.Id);
            StatusMessage = result.Message;
            LoadHighlights(ActiveDocument.Id);
        }

        [RelayCommand]
        private void HoverTableCell(TableCellViewModel? cell)
        {
            if (cell is null) return;

            foreach (var c in TableCells)
            {
                c.IsSelected = c.Row <= cell.Row && c.Column <= cell.Column;
            }

            TableSelectorText = $"{cell.Row + 1} x {cell.Column + 1} Table";
        }

        [RelayCommand]
        private void ResetTableSelection()
        {
            foreach (var c in TableCells)
            {
                c.IsSelected = false;
            }
            TableSelectorText = "Insert Table";
        }

        [RelayCommand]
        private void InsertTable(TableCellViewModel? cell)
        {
            if (cell is null) return;

            TableInsertRequested?.Invoke(cell.Row + 1, cell.Column + 1);
        }

        partial void OnNoteTextChanged(string value)
        {
            if (_isLoadingNote || ActiveDocument is not { } document)
            {
                return;
            }

            ScheduleNoteSave(document.Id, value);
        }

        private void ScheduleNoteSave(string documentId, string value)
        {
            _saveNoteDebounce?.Cancel();
            _saveNoteDebounce = new CancellationTokenSource();

            var token = _saveNoteDebounce.Token;

            _ = Task.Run(async () =>
            {
                try
                {
                    await Task.Delay(500, token);

                    if (!token.IsCancellationRequested)
                    {
                        var result = _noteService.SaveNote(documentId, value);
                        Dispatcher.UIThread.Post(() =>
                        {
                            StatusMessage = result.Message;
                        });
                    }
                }
                catch (TaskCanceledException)
                {
                }
            }, token);
        }

        private void SaveActiveNoteImmediately()
        {
            _saveNoteDebounce?.Cancel();

            if (ActiveDocument is null)
            {
                return;
            }

            var result = _noteService.SaveNote(ActiveDocument.Id, NoteText);
            StatusMessage = result.Message;
        }
    }
}
