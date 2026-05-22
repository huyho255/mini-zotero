using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class TabWorkspaceViewModel : ViewModelBase
    {
        public TabWorkspaceViewModel()
            : this(_ => { })
        {
        }

        public TabWorkspaceViewModel(Action<DocumentItem> persistReadingState)
        {
            PdfViewer = new PdfViewerViewModel(persistReadingState);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        public PdfViewerViewModel PdfViewer { get; }

        public bool IsEmptyViewVisible => ActiveDocument is null;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            PdfViewer.LoadDocument(document);
        }
    }
}
