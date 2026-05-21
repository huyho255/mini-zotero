using System.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.ViewModels;

public class NotePreviewPanelViewModel : INotifyPropertyChanged
{
    private readonly NoteRepository _noteRepository;

    private DocumentItem? _activeDocument;
    private bool _hasActiveDocument;
    private string _noteText = string.Empty;
    private string _notePlaceholder = "Open a document to start taking notes...";
    private string _previewTitle = "Preview highlights";
    private string _previewDescription = "Highlights from the current PDF will appear here.";

    public event PropertyChangedEventHandler? PropertyChanged;

    public NotePreviewPanelViewModel(NoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public bool HasActiveDocument
    {
        get => _hasActiveDocument;
        private set
        {
            if (_hasActiveDocument == value)
            {
                return;
            }

            _hasActiveDocument = value;
            OnPropertyChanged(nameof(HasActiveDocument));
        }
    }

    public string NoteText
    {
        get => _noteText;
        set
        {
            if (_noteText == value)
            {
                return;
            }

            _noteText = value;
            OnPropertyChanged(nameof(NoteText));

            if (_activeDocument is not null)
            {
                _noteRepository.SaveNote(_activeDocument.Id, _noteText);
            }
        }
    }

    public string NotePlaceholder
    {
        get => _notePlaceholder;
        private set
        {
            if (_notePlaceholder == value)
            {
                return;
            }

            _notePlaceholder = value;
            OnPropertyChanged(nameof(NotePlaceholder));
        }
    }

    public string PreviewTitle
    {
        get => _previewTitle;
        private set
        {
            if (_previewTitle == value)
            {
                return;
            }

            _previewTitle = value;
            OnPropertyChanged(nameof(PreviewTitle));
        }
    }

    public string PreviewDescription
    {
        get => _previewDescription;
        private set
        {
            if (_previewDescription == value)
            {
                return;
            }

            _previewDescription = value;
            OnPropertyChanged(nameof(PreviewDescription));
        }
    }

    public string EmptyHighlightTitle { get; } = "No highlights yet";

    public string EmptyHighlightMessage { get; } = "Select text in a PDF to create highlights";

    public void SetActiveDocument(DocumentItem document)
    {
        _activeDocument = document;

        HasActiveDocument = true;

        NotePlaceholder = $"Write notes for {document.Title}...";
        PreviewTitle = "Preview highlights";
        PreviewDescription = $"Highlights from {document.Title} will appear here.";

        NoteText = _noteRepository.LoadNote(document.Id);
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
