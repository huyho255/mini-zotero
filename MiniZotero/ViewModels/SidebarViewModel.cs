using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly DocumentRepository _documentRepository;

        public SidebarViewModel()
            : this(new DocumentRepository(new AppStorageService()))
        {
        }

        public SidebarViewModel(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;

            foreach (var document in _documentRepository.LoadDocuments())
            {
                Documents.Add(document);
            }

            NotifyDocumentStateChanged();
        }

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

            var document = _documentRepository.ImportDocument(filePath, Documents);
            if (!Documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                Documents.Add(document);
            }

            _documentRepository.SaveDocuments(Documents);
            NotifyDocumentStateChanged();

            SelectedDocument = document;
        }

        private void NotifyDocumentStateChanged()
        {
            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
        }
    }
}
