using System.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels;

public class TabWorkspaceViewModel : INotifyPropertyChanged
{
    private bool _hasOpenDocument;
    private string _currentTabTitle = "No document opened";

    public event PropertyChangedEventHandler? PropertyChanged;

    public PdfViewerViewModel PdfViewer { get; } = new();

    public bool HasOpenDocument
    {
        get => _hasOpenDocument;
        private set
        {
            if (_hasOpenDocument == value)
            {
                return;
            }

            _hasOpenDocument = value;
            OnPropertyChanged(nameof(HasOpenDocument));
        }
    }

    public string CurrentTabTitle
    {
        get => _currentTabTitle;
        private set
        {
            if (_currentTabTitle == value)
            {
                return;
            }

            _currentTabTitle = value;
            OnPropertyChanged(nameof(CurrentTabTitle));
        }
    }

    public string SearchHint { get; } = "Search";

    public void OpenDocument(DocumentItem document)
    {
        HasOpenDocument = true;
        CurrentTabTitle = document.Title;

        PdfViewer.LoadDocument(document);
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
