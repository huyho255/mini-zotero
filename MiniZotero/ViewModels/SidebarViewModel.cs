using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public sealed partial class SidebarNavigationItem : ObservableObject
    {
        public SidebarNavigationItem(
            string name,
            string icon,
            string? countText = null)
        {
            Name = name;
            Icon = icon;
            CountText = countText;
        }

        public string Name { get; }

        public string Icon { get; }

        [ObservableProperty]
        private string? _countText;
    }

    public sealed class SmartCollectionItem
    {
        public SmartCollectionItem(
            string name,
            string icon,
            string iconColor,
            int count)
        {
            Name = name;
            Icon = icon;
            IconColor = iconColor;
            Count = count;
        }

        public string Name { get; }

        public string Icon { get; }

        public string IconColor { get; }

        public int Count { get; }
    }

    public sealed class TagItem
    {
        public TagItem(string name, string? countText = null)
        {
            Name = name;
            CountText = countText;
        }

        public string Name { get; }

        public string? CountText { get; }
    }

    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly DocumentRepository _documentRepository;
        private readonly SidebarNavigationItem _libraryNavigationItem;

        public SidebarViewModel()
            : this(new DocumentRepository(new AppStorageService()))
        {
        }

        public SidebarViewModel(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;

            _libraryNavigationItem = new SidebarNavigationItem("Library", "\uE8B7", "0");
            NavigationItems.Add(_libraryNavigationItem);
            NavigationItems.Add(new SidebarNavigationItem("Recent", "\uE823"));
            NavigationItems.Add(new SidebarNavigationItem("Starred", "\uE734"));
            NavigationItems.Add(new SidebarNavigationItem("Trash", "\uE74D"));
            SelectedNavigationItem = _libraryNavigationItem;

            SmartCollections.Add(new SmartCollectionItem("Đang đọc dở", "\uE7C1", "#8DD6A5", 24));
            SmartCollections.Add(new SmartCollectionItem("Tài liệu C#", "\uE8A5", "#D9C7FF", 56));
            SmartCollections.Add(new SmartCollectionItem("Bài báo khoa học", "\uE8A5", "#D175FF", 18));
            SmartCollections.Add(new SmartCollectionItem("System Design", "\uE8A5", "#D6D300", 31));
            SmartCollections.Add(new SmartCollectionItem("Sách hay", "\uE8A5", "#36D6D6", 12));
            SmartCollections.Add(new SmartCollectionItem("Data Sheet", "\uE8A5", "#9CCBFF", 7));
            SmartCollections.Add(new SmartCollectionItem("Archived", "\uE8A5", "#B774FF", 102));
            SelectedSmartCollection = SmartCollections.FirstOrDefault(collection =>
                collection.Name == "Tài liệu C#");

            Tags.Add(new TagItem("C#", "56"));
            Tags.Add(new TagItem(".NET"));
            Tags.Add(new TagItem("Architecture", "48"));
            Tags.Add(new TagItem("Design Patterns", "38"));
            Tags.Add(new TagItem("Clean Code", "21"));
            Tags.Add(new TagItem("Software Engineering", "40"));
            Tags.Add(new TagItem("Database", "22"));
            Tags.Add(new TagItem("AI", "15"));
            Tags.Add(new TagItem("Linux", "17"));
            Tags.Add(new TagItem("... More"));

            foreach (var document in _documentRepository.LoadDocuments())
            {
                Documents.Add(document);
            }

            NotifyDocumentStateChanged();
        }

        [ObservableProperty]
        private DocumentItem? _selectedDocument;

        [ObservableProperty]
        private SidebarNavigationItem? _selectedNavigationItem;

        [ObservableProperty]
        private SmartCollectionItem? _selectedSmartCollection;

        [ObservableProperty]
        private TagItem? _selectedTag;

        public ObservableCollection<SidebarNavigationItem> NavigationItems { get; } = new();

        public ObservableCollection<SmartCollectionItem> SmartCollections { get; } = new();

        public ObservableCollection<TagItem> Tags { get; } = new();

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
            _libraryNavigationItem.CountText = DocumentCount.ToString();
            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
        }
    }
}
