using System.Collections.ObjectModel;
using System.IO;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class SidebarViewModel : ViewModelBase
    {
        [ObservableProperty]
        private DocumentItem? _selectedDocument;

        public ObservableCollection<DocumentItem> Documents { get; } = new();

        public int DocumentCount => Documents.Count;

        public bool HasDocuments => Documents.Count > 0;

        public bool IsEmptyViewVisible => !HasDocuments;

        public void AddDocument(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            var title = Path.GetFileName(filePath);
            var document = new DocumentItem(title, filePath);
            Documents.Add(document);

            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(IsEmptyViewVisible));

            SelectedDocument = document;
        }
    }
}
