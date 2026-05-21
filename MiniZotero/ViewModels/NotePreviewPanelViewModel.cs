using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class NotePreviewPanelViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasDocument))]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        [ObservableProperty]
        private string _noteText = string.Empty;

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            NoteText = string.Empty;
        }
    }
}
