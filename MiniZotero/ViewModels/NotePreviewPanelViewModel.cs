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
        private readonly NoteService _noteService;
        private readonly HighlightService _highlightService;
        private CancellationTokenSource? _saveNoteDebounce;
        private bool _isLoadingNote;

        public NotePreviewPanelViewModel(
            NoteService noteService,
            HighlightService highlightService)
        {
            _noteService = noteService;
            _highlightService = highlightService;
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

        public ObservableCollection<HighlightItem> Highlights { get; } = [];

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public bool HasHighlights => Highlights.Count > 0;

        public bool IsHighlightEmptyViewVisible => HasDocument && !HasHighlights;

        public event Action<HighlightItem>? HighlightSelected;

        public event Action? HighlightsChanged;

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
