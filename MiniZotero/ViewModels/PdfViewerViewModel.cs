using System.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels;

public class PdfViewerViewModel : INotifyPropertyChanged
{
    private bool _hasDocumentLoaded;
    private string _documentPath = string.Empty;
    private string _emptyTitle = "Select a document to view";
    private string _emptyMessage = "or import a new PDF file";
    private string _statusText = "Ready";
    private string _documentStatus = "No document loaded";

    public event PropertyChangedEventHandler? PropertyChanged;

    public bool HasDocumentLoaded
    {
        get => _hasDocumentLoaded;
        private set
        {
            if (_hasDocumentLoaded == value)
            {
                return;
            }

            _hasDocumentLoaded = value;
            OnPropertyChanged(nameof(HasDocumentLoaded));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
        }
    }

    public bool IsEmptyViewVisible => !HasDocumentLoaded;

    public string DocumentPath
    {
        get => _documentPath;
        private set
        {
            if (_documentPath == value)
            {
                return;
            }

            _documentPath = value;
            OnPropertyChanged(nameof(DocumentPath));
        }
    }

    public string EmptyTitle
    {
        get => _emptyTitle;
        private set
        {
            if (_emptyTitle == value)
            {
                return;
            }

            _emptyTitle = value;
            OnPropertyChanged(nameof(EmptyTitle));
        }
    }

    public string EmptyMessage
    {
        get => _emptyMessage;
        private set
        {
            if (_emptyMessage == value)
            {
                return;
            }

            _emptyMessage = value;
            OnPropertyChanged(nameof(EmptyMessage));
        }
    }

    public string StatusText
    {
        get => _statusText;
        private set
        {
            if (_statusText == value)
            {
                return;
            }

            _statusText = value;
            OnPropertyChanged(nameof(StatusText));
        }
    }

    public string DocumentStatus
    {
        get => _documentStatus;
        private set
        {
            if (_documentStatus == value)
            {
                return;
            }

            _documentStatus = value;
            OnPropertyChanged(nameof(DocumentStatus));
        }
    }

    public void LoadDocument(DocumentItem document)
    {
        DocumentPath = document.FilePath;
        HasDocumentLoaded = true;

        EmptyTitle = document.Title;
        EmptyMessage = string.Empty;

        StatusText = "Document loaded";
        DocumentStatus = document.FilePath;
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
