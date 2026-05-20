using System.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels;

public class NotePreviewPanelViewModel : INotifyPropertyChanged
{
    private bool _hasActiveDocument;
    private string _notePlaceholder = "Open a document to start taking notes...";
    private string _previewTitle = "Preview highlights";
    private string _previewDescription = "Highlights from the current PDF will appear here.";

    public event PropertyChangedEventHandler? PropertyChanged;

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
        HasActiveDocument = true;
        NotePlaceholder = $"Write notes for {document.Title}...";
        PreviewTitle = "Preview highlights";
        PreviewDescription = $"Highlights from {document.Title} will appear here.";
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
