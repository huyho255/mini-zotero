using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

    public sealed partial class SmartCollectionItem : ObservableObject
    {
        public SmartCollectionItem(
            string name,
            string kind,
            string icon,
            string iconColor,
            int count = 0)
        {
            Name = name;
            Kind = kind;
            Icon = icon;
            IconColor = iconColor;
            Count = count;
        }

        public string Name { get; }

        public string Kind { get; }

        public string Icon { get; }

        public string IconColor { get; }

        [ObservableProperty]
        private int _count;

    }

    public sealed partial class TagItem : ObservableObject
    {
        public TagItem(string name, string? countText = null)
        {
            Name = name;
            CountText = countText;
        }

        public string Name { get; }

        [ObservableProperty]
        private string? _countText;
    }

    public sealed class DocumentExplorerItem
    {
        private DocumentExplorerItem(
            string name,
            string icon,
            bool isFolder,
            DocumentItem? document,
            int count = 0,
            bool isExpanded = false)
        {
            Name = name;
            Icon = icon;
            IsFolder = isFolder;
            Document = document;
            Count = count;
            IsExpanded = isExpanded;
        }

        public string Name { get; }

        public string Icon { get; }

        public bool IsFolder { get; }

        public bool IsDocument => Document is not null;

        public DocumentItem? Document { get; }

        public int Count { get; }

        public bool IsExpanded { get; }

        public string ChevronIcon => IsFolder
            ? IsExpanded ? "\uE70D" : "\uE76C"
            : string.Empty;

        public string IconForeground => IsFolder ? "#7DD3FC" : "#52C7FF";

        public int IconFontSize => IsFolder ? 13 : 12;

        public string NameForeground => IsFolder ? "#F2F6FC" : "#E4EBF4";

        public string NameFontWeight => IsFolder ? "SemiBold" : "Normal";

        public bool IsStarred => Document?.IsStarred == true;

        public bool IsStarButtonVisible => IsDocument && Document?.IsDeleted != true;

        public static DocumentExplorerItem Folder(string name, int count, bool isExpanded)
        {
            return new DocumentExplorerItem(name, "\uE8B7", isFolder: true, document: null, count, isExpanded);
        }

        public static DocumentExplorerItem File(DocumentItem document)
        {
            return new DocumentExplorerItem(document.Title, "\uE7C3", isFolder: false, document);
        }
    }

    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly DocumentRepository _documentRepository;
        private readonly AppSettingsRepository _settingsRepository;
        private readonly WatchFolderService _watchFolderService;
        private readonly StorageUsageService _storageUsageService;
        private readonly SidebarNavigationItem _libraryNavigationItem;
        private readonly SidebarNavigationItem _recentNavigationItem;
        private readonly SidebarNavigationItem _starredNavigationItem;
        private readonly SidebarNavigationItem _trashNavigationItem;
        private readonly Dictionary<string, bool> _expandedFolders = new(StringComparer.OrdinalIgnoreCase);
        private bool _isRebuildingTags;

        public SidebarViewModel()
            : this(
                new DocumentRepository(new AppStorageService(), new AutoTagService()),
                new AppSettingsRepository(new AppStorageService()),
                new WatchFolderService(),
                new StorageUsageService())
        {
        }

        public SidebarViewModel(
            DocumentRepository documentRepository,
            AppSettingsRepository settingsRepository,
            WatchFolderService watchFolderService,
            StorageUsageService storageUsageService)
        {
            _documentRepository = documentRepository;
            _settingsRepository = settingsRepository;
            _watchFolderService = watchFolderService;
            _storageUsageService = storageUsageService;
            _watchFolderService.PdfDetected += OnWatchFolderPdfDetected;

            _libraryNavigationItem = new SidebarNavigationItem("Library", "\uE8B7", "0");
            _recentNavigationItem = new SidebarNavigationItem("Recent", "\uE823", "0");
            _starredNavigationItem = new SidebarNavigationItem("Starred", "\uE734", "0");
            _trashNavigationItem = new SidebarNavigationItem("Trash", "\uE74D", "0");

            NavigationItems.Add(_libraryNavigationItem);
            NavigationItems.Add(_recentNavigationItem);
            NavigationItems.Add(_starredNavigationItem);
            NavigationItems.Add(_trashNavigationItem);
            SelectedNavigationItem = _libraryNavigationItem;
            SmartCollections.Clear();
            SmartCollections.Add(new SmartCollectionItem("Đang đọc dở", "reading", "\uE7C1", "#8DD6A5"));
            SmartCollections.Add(new SmartCollectionItem("Mới thêm", "new", "\uE8A5", "#9CCBFF"));
            SmartCollections.Add(new SmartCollectionItem("Đã mở gần đây", "recent", "\uE823", "#D9C7FF"));
            SmartCollections.Add(new SmartCollectionItem("Chưa đọc", "unread", "\uE7BE", "#FBBF24"));
            SelectedSmartCollection = null;
            SelectedNavigationItem = _libraryNavigationItem;

            var settings = _settingsRepository.LoadSettings();
            WatchFolderPath = settings.WatchFolderPath;

            if (!string.IsNullOrWhiteSpace(WatchFolderPath))
            {
                _watchFolderService.Start(WatchFolderPath);
            }

            foreach (var document in _documentRepository.LoadDocuments())
            {
                Documents.Add(document);
            }

            RebuildTags();
            ApplyDocumentFilter();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasSelectedDocument))]
        [NotifyPropertyChangedFor(nameof(IsMoveToTrashVisible))]
        [NotifyPropertyChangedFor(nameof(IsTrashDocumentActionsVisible))]
        [NotifyPropertyChangedFor(nameof(IsTagEditorVisible))]
        private DocumentItem? _selectedDocument;

        [ObservableProperty]
        private DocumentExplorerItem? _selectedExplorerItem;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private string _newTagText = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsWatchFolderConfigured))]
        [NotifyPropertyChangedFor(nameof(WatchFolderStatusText))]
        private string? _watchFolderPath;

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

        public ObservableCollection<DocumentItem> FilteredDocuments { get; } = new();

        public ObservableCollection<DocumentItem> SearchResultDocuments { get; } = new();

        public ObservableCollection<DocumentExplorerItem> DocumentExplorerItems { get; } = new();

        public int DocumentCount => FilteredDocuments.Count;

        public bool HasDocuments => Documents.Count > 0;

        public bool HasVisibleDocuments => FilteredDocuments.Count > 0;

        public bool HasSelectedDocument => SelectedDocument is not null;

        public bool IsEmptyViewVisible => Documents.Count == 0;

        public bool IsTrashSelected => SelectedNavigationItem?.Name == "Trash";

        public bool IsMoveToTrashVisible =>
            HasSelectedDocument && !IsTrashSelected && SelectedDocument?.IsDeleted != true;

        public bool IsTrashDocumentActionsVisible =>
            HasSelectedDocument && IsTrashSelected && SelectedDocument?.IsDeleted == true;

        public bool IsTagEditorVisible =>
            HasSelectedDocument && !IsTrashSelected && SelectedDocument?.IsDeleted != true;

        public bool HasSearchText => !string.IsNullOrWhiteSpace(SearchText);

        public bool HasSearchResults => HasSearchText && SearchResultDocuments.Count > 0;

        public bool IsSearchDropdownVisible => HasSearchText;

        public bool IsNoSearchResultVisible =>
            HasSearchText && SearchResultDocuments.Count == 0;

        public string CurrentDocumentSectionTitle =>
            SelectedSmartCollection is not null
                ? SelectedSmartCollection.Name.ToUpperInvariant()
                : SelectedNavigationItem?.Name switch
                {
                    "Recent" => "RECENT DOCUMENTS",
                    "Starred" => "STARRED",
                    "Trash" => "TRASH",
                    _ => "DOCUMENTS"
                };

        public bool IsWatchFolderConfigured => !string.IsNullOrWhiteSpace(WatchFolderPath);

        public string WatchFolderStatusText =>
            IsWatchFolderConfigured
                ? $"Đang theo dõi: {Path.GetFileName(WatchFolderPath)}"
                : "Not configured";

        public string StorageUsageText
        {
            get
            {
                var bytes = _storageUsageService.GetLibraryUsageBytes(Documents);
                return $"Storage  {_storageUsageService.FormatByteCount(bytes)} used";
            }
        }

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
            else if (document.IsDeleted)
            {
                document.IsDeleted = false;
                document.DeletedAt = null;
            }

            PersistDocumentsAndRefresh();

            SelectedDocument = document;
        }

        public void SetWatchFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return;
            }

            WatchFolderPath = folderPath;

            _settingsRepository.SaveSettings(new AppSettings
            {
                WatchFolderPath = folderPath
            });

            _watchFolderService.Start(folderPath);
        }

        partial void OnSearchTextChanged(string value)
        {
            ApplySearchFilter();
        }

        partial void OnSelectedTagChanged(TagItem? value)
        {
            if (!_isRebuildingTags)
            {
                ApplyDocumentFilter();
            }
        }

        partial void OnSelectedSmartCollectionChanged(SmartCollectionItem? value)
        {
            if (value is not null)
            {
                SelectedNavigationItem = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        partial void OnSelectedDocumentChanged(DocumentItem? value)
        {
            if (value is null)
            {
                OnPropertyChanged(nameof(IsMoveToTrashVisible));
                OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
                OnPropertyChanged(nameof(IsTagEditorVisible));
                return;
            }

            var matchingExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                item.Document?.Id == value.Id);
            if (matchingExplorerItem is not null && SelectedExplorerItem != matchingExplorerItem)
            {
                SelectedExplorerItem = matchingExplorerItem;
            }

            if (HasSearchText)
            {
                SearchText = string.Empty;
            }

            Dispatcher.UIThread.Post(() =>
            {
                if (value.IsDeleted)
                {
                    return;
                }

                value.LastOpenedAt = DateTimeOffset.Now;
                _documentRepository.SaveDocuments(Documents);

                if (ShouldRefreshDocumentListAfterOpen())
                {
                    ApplyDocumentFilter();
                    ApplySearchFilter();
                }
                else
                {
                    NotifyDocumentStateChanged();
                }
            });
        }

        partial void OnSelectedExplorerItemChanged(DocumentExplorerItem? value)
        {
            if (value?.Document is { } document && SelectedDocument != document)
            {
                SelectedDocument = document;
                return;
            }

            if (value?.IsFolder == true)
            {
                Dispatcher.UIThread.Post(() =>
                {
                    SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                        item.Document?.Id == SelectedDocument?.Id);
                });
            }
        }

        partial void OnSelectedNavigationItemChanged(SidebarNavigationItem? value)
        {
            if (value is not null)
            {
                SelectedSmartCollection = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        [RelayCommand]
        private void ToggleStar(DocumentItem? document)
        {
            if (document is null || document.IsDeleted)
            {
                return;
            }

            document.IsStarred = !document.IsStarred;

            PersistDocumentsAndRefresh(rebuildTags: false);
        }

        [RelayCommand]
        private void ToggleFolder(DocumentExplorerItem? item)
        {
            if (item?.IsFolder != true)
            {
                return;
            }

            _expandedFolders[item.Name] = !item.IsExpanded;
            ApplyDocumentFilter();
        }

        [RelayCommand]
        private void AddTagToSelectedDocument()
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted)
            {
                return;
            }

            var tag = NewTagText.Trim();
            if (string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            SelectedDocument.Tags ??= [];

            var exists = SelectedDocument.Tags.Any(existingTag =>
                string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

            if (!exists)
            {
                SelectedDocument.Tags.Add(tag);
            }

            NewTagText = string.Empty;

            PersistDocumentsAndRefresh();
        }

        [RelayCommand]
        private void RemoveTagFromSelectedDocument(string? tag)
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted || string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            SelectedDocument.Tags.RemoveAll(existingTag =>
                string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

            PersistDocumentsAndRefresh();
        }

        private void OnWatchFolderPdfDetected(string filePath)
        {
            Dispatcher.UIThread.Post(() =>
            {
                AddDocument(filePath);
            });
        }

        [RelayCommand]
        private void MoveSelectedDocumentToTrash()
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted)
            {
                return;
            }

            SelectedDocument.IsDeleted = true;
            SelectedDocument.DeletedAt = DateTimeOffset.Now;

            SelectedDocument = null;
            PersistDocumentsAndRefresh();
        }

        [RelayCommand]
        private void RestoreSelectedDocument()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            SelectedDocument.IsDeleted = false;
            SelectedDocument.DeletedAt = null;

            SelectedDocument = null;
            PersistDocumentsAndRefresh();
        }

        [RelayCommand]
        private void DeleteSelectedDocumentForever()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            var document = SelectedDocument;
            SelectedDocument = null;

            _documentRepository.DeleteStoredPdfFile(document);
            Documents.Remove(document);

            PersistDocumentsAndRefresh();
        }

        private void PersistDocumentsAndRefresh(bool rebuildTags = true)
        {
            _documentRepository.SaveDocuments(Documents);

            if (rebuildTags)
            {
                RebuildTags();
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        private bool ShouldRefreshDocumentListAfterOpen()
        {
            return SelectedNavigationItem?.Name == "Recent" ||
                   SelectedSmartCollection?.Kind is "recent" or "unread";
        }

        private void ApplyDocumentFilter()
        {
            FilteredDocuments.Clear();
            DocumentExplorerItems.Clear();

            var documents = ApplySmartCollectionFilter(GetNavigationDocuments());

            if (SelectedTag is not null)
            {
                documents = documents.Where(document =>
                    document.Tags.Any(tag =>
                        string.Equals(tag, SelectedTag.Name, StringComparison.OrdinalIgnoreCase)));
            }

            var filteredDocuments = documents.ToList();

            if (SelectedDocument is not null &&
                filteredDocuments.All(document => document.Id != SelectedDocument.Id))
            {
                SelectedDocument = null;
            }

            foreach (var document in filteredDocuments)
            {
                FilteredDocuments.Add(document);
            }

            BuildDocumentExplorerItems(filteredDocuments);

            NotifyDocumentStateChanged();
        }

        private void RebuildTags()
        {
            var selectedTagName = SelectedTag?.Name;

            _isRebuildingTags = true;

            try
            {
                Tags.Clear();

                var tagGroups = Documents
                    .Where(document => !document.IsDeleted)
                    .SelectMany(document => document.Tags)
                    .Where(tag => !string.IsNullOrWhiteSpace(tag))
                    .GroupBy(tag => tag.Trim(), StringComparer.OrdinalIgnoreCase)
                    .OrderBy(group => group.Key);

                foreach (var group in tagGroups)
                {
                    Tags.Add(new TagItem(group.Key, group.Count().ToString()));
                }

                SelectedTag = !string.IsNullOrWhiteSpace(selectedTagName)
                    ? Tags.FirstOrDefault(tag =>
                        string.Equals(tag.Name, selectedTagName, StringComparison.OrdinalIgnoreCase))
                    : null;
            }
            finally
            {
                _isRebuildingTags = false;
            }
        }

        private void BuildDocumentExplorerItems(IReadOnlyList<DocumentItem> documents)
        {
            var groups = documents
                .GroupBy(GetDocumentFolderName)
                .OrderBy(group => group.Key);

            foreach (var group in groups)
            {
                var isExpanded = IsFolderExpanded(group.Key);
                DocumentExplorerItems.Add(DocumentExplorerItem.Folder(group.Key, group.Count(), isExpanded));

                if (!isExpanded)
                {
                    continue;
                }

                foreach (var document in group)
                {
                    DocumentExplorerItems.Add(DocumentExplorerItem.File(document));
                }
            }

            SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                item.Document?.Id == SelectedDocument?.Id);
        }

        private bool IsFolderExpanded(string folderName)
        {
            if (!_expandedFolders.TryGetValue(folderName, out var isExpanded))
            {
                _expandedFolders[folderName] = false;
                return false;
            }

            return isExpanded;
        }

        private static string GetDocumentFolderName(DocumentItem document)
        {
            var path = !string.IsNullOrWhiteSpace(document.OriginalFilePath)
                ? document.OriginalFilePath
                : document.FilePath;

            var folderPath = Path.GetDirectoryName(path);
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                return "Documents";
            }

            return Path.GetFileName(folderPath) is { Length: > 0 } folderName
                ? folderName
                : folderPath;
        }

        private void ApplySearchFilter()
        {
            SearchResultDocuments.Clear();

            var query = SearchText?.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                NotifyDocumentStateChanged();
                return;
            }

            var documents = ApplySmartCollectionFilter(GetNavigationDocuments())
                .Where(document => MatchesSearch(document, query))
                .OrderBy(document => document.Title);

            foreach (var document in documents)
            {
                SearchResultDocuments.Add(document);
            }

            NotifyDocumentStateChanged();
        }

        private static bool MatchesSearch(DocumentItem document, string keyword)
        {
            return Contains(document.Title, keyword) ||
                   Contains(document.FilePath, keyword) ||
                   Contains(document.OriginalFilePath, keyword) ||
                   document.Tags.Any(tag => Contains(tag, keyword));
        }

        private static bool Contains(string? value, string keyword)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }

        private IEnumerable<DocumentItem> GetNavigationDocuments()
        {
            var documents = Documents.AsEnumerable();

            return SelectedNavigationItem?.Name switch
            {
                "Recent" => documents
                    .Where(document => !document.IsDeleted && document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "Starred" => documents
                    .Where(document => !document.IsDeleted && document.IsStarred)
                    .OrderBy(document => document.Title),

                "Trash" => documents
                    .Where(document => document.IsDeleted)
                    .OrderByDescending(document => document.DeletedAt),

                _ => documents
                    .Where(document => !document.IsDeleted)
                    .OrderBy(document => document.Title)
            };
        }

        private IEnumerable<DocumentItem> ApplySmartCollectionFilter(IEnumerable<DocumentItem> documents)
        {
            return SelectedSmartCollection?.Kind switch
            {
                "reading" => documents.Where(document => document.LastReadPage > 1),

                "new" => documents.Where(document =>
                    document.AddedAt >= DateTimeOffset.Now.AddDays(-7)),

                "recent" => documents
                    .Where(document => document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "unread" => documents.Where(document => document.LastOpenedAt is null),

                _ => documents
            };
        }

        private void NotifyDocumentStateChanged()
        {
            RefreshSmartCollectionCounts();

            _libraryNavigationItem.CountText = Documents.Count(document => !document.IsDeleted).ToString();
            _recentNavigationItem.CountText = Documents.Count(document => !document.IsDeleted && document.LastOpenedAt is not null).ToString();
            _starredNavigationItem.CountText = Documents.Count(document => !document.IsDeleted && document.IsStarred).ToString();
            _trashNavigationItem.CountText = Documents.Count(document => document.IsDeleted).ToString();

            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(HasVisibleDocuments));
            OnPropertyChanged(nameof(HasSelectedDocument));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
            OnPropertyChanged(nameof(HasSearchText));
            OnPropertyChanged(nameof(HasSearchResults));
            OnPropertyChanged(nameof(IsSearchDropdownVisible));
            OnPropertyChanged(nameof(IsNoSearchResultVisible));
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
            OnPropertyChanged(nameof(StorageUsageText));
        }

        private void RefreshSmartCollectionCounts()
        {
            var newDocumentThreshold = DateTimeOffset.Now.AddDays(-7);

            foreach (var collection in SmartCollections)
            {
                collection.Count = collection.Kind switch
                {
                    "reading" => Documents.Count(document =>
                        !document.IsDeleted && document.LastReadPage > 1),

                    "new" => Documents.Count(document =>
                        !document.IsDeleted && document.AddedAt >= newDocumentThreshold),

                    "recent" => Documents.Count(document =>
                        !document.IsDeleted && document.LastOpenedAt is not null),

                    "unread" => Documents.Count(document =>
                        !document.IsDeleted && document.LastOpenedAt is null),

                    _ => 0
                };
            }
        }

    }
}
