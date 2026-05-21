using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class TabWorkspaceViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        public PdfViewerViewModel PdfViewer { get; } = new();

        public bool IsEmptyViewVisible => ActiveDocument is null;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            PdfViewer.LoadDocument(document);
        }
    }
}
