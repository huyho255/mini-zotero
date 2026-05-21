using System;
using System.ComponentModel;
using System.IO;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels;

public class PdfViewerViewModel : INotifyPropertyChanged
{
    private static readonly PdfJsServerService PdfServer = new();

    private bool _hasDocumentLoaded;
    private Uri? _viewerSource;
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

    public Uri? ViewerSource
    {
        get => _viewerSource;
        private set
        {
            if (_viewerSource == value)
            {
                return;
            }

            _viewerSource = value;
            OnPropertyChanged(nameof(ViewerSource));
        }
    }

    public string EmptyTitle
    {
        get => _emptyTitle;
        private set
        {
            _emptyTitle = value;
            OnPropertyChanged(nameof(EmptyTitle));
        }
    }

    public string EmptyMessage
    {
        get => _emptyMessage;
        private set
        {
            _emptyMessage = value;
            OnPropertyChanged(nameof(EmptyMessage));
        }
    }

    public string StatusText
    {
        get => _statusText;
        private set
        {
            _statusText = value;
            OnPropertyChanged(nameof(StatusText));
        }
    }

    public string DocumentStatus
    {
        get => _documentStatus;
        private set
        {
            _documentStatus = value;
            OnPropertyChanged(nameof(DocumentStatus));
        }
    }

    public void LoadDocument(DocumentItem document)
    {
        if (!File.Exists(document.FilePath))
        {
            StatusText = "File not found";
            DocumentStatus = document.FilePath;
            return;
        }

        PdfServer.Start();

        string viewerUrl = PdfServer.RegisterPdf(document.Id, document.FilePath);

        ViewerSource = new Uri(viewerUrl);
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
