using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class NotePreviewPanelViewModel : ViewModelBase
    {
        private readonly NoteRepository _noteRepository;
        private readonly HighlightRepository _highlightRepository;
        private readonly MarkdownExportService _markdownExportService;
        private bool _isLoadingNote;

        public NotePreviewPanelViewModel(
            NoteRepository noteRepository,
            HighlightRepository highlightRepository,
            MarkdownExportService markdownExportService)
        {
            _noteRepository = noteRepository;
            _highlightRepository = highlightRepository;
            _markdownExportService = markdownExportService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasDocument))]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        [NotifyPropertyChangedFor(nameof(HasHighlights))]
        [NotifyPropertyChangedFor(nameof(IsHighlightEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        [ObservableProperty]
        private string _noteText = string.Empty;

        public ObservableCollection<HighlightItem> Highlights { get; } = [];

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public bool HasHighlights => Highlights.Count > 0;

        public bool IsHighlightEmptyViewVisible => HasDocument && !HasHighlights;

        public event Action<HighlightItem>? HighlightSelected;

        public event Action? HighlightsChanged;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            _isLoadingNote = true;

            try
            {
                NoteText = _noteRepository.LoadNote(document.Id);
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

            var highlight = new HighlightItem
            {
                DocumentId = ActiveDocument.Id,
                PageNumber = pageNumber < 1 ? 1 : pageNumber,
                Text = text.Trim(),
                Color = "yellow",
                Rects = rects.ToList()
            };

            _highlightRepository.AddHighlight(highlight);
            LoadHighlights(ActiveDocument.Id);
        }

        public void ExportActiveDocumentToMarkdown(string outputPath)
        {
            if (ActiveDocument is null)
            {
                return;
            }

            _markdownExportService.ExportDocumentNotes(
                ActiveDocument,
                NoteText,
                Highlights,
                outputPath);
        }

        private void LoadHighlights(string documentId)
        {
            Highlights.Clear();

            foreach (var highlight in _highlightRepository.LoadHighlights(documentId))
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

            _highlightRepository.DeleteHighlight(ActiveDocument.Id, highlight.Id);
            LoadHighlights(ActiveDocument.Id);
        }

        partial void OnNoteTextChanged(string value)
        {
            if (_isLoadingNote || ActiveDocument is not { } document)
            {
                return;
            }

            _noteRepository.SaveNote(document.Id, value);
        }
    }
}
