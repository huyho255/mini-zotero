using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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

        public string StarIcon => IsStarred ? "\uE735" : "\uE734";

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
        private readonly ILibraryService _libraryService;
        private readonly IDocumentImportService _documentImportService;
        private readonly TagService _tagService;
        private readonly ICollectionRepository _collectionRepository;
        private readonly ICollectionService _collectionService;
        private readonly IAppSettingsRepository _settingsRepository;
        private readonly WatchFolderService _watchFolderService;
        private readonly StorageUsageService _storageUsageService;
        private readonly IFilePickerService _filePickerService;
        private readonly SidebarNavigationItem _libraryNavigationItem;
        private readonly SidebarNavigationItem _recentNavigationItem;
        private readonly SidebarNavigationItem _starredNavigationItem;
        private readonly SidebarNavigationItem _trashNavigationItem;
        private readonly Dictionary<string, bool> _expandedFolders = new(StringComparer.OrdinalIgnoreCase);
        private bool _isRebuildingTags;
        private readonly Dictionary<string, int> _folderStartIndices = new();
        private int _displayLimit = 10;
        private IReadOnlyList<DocumentItem> _currentFilteredDocuments = Array.Empty<DocumentItem>();

        public SidebarViewModel()
            : this(new ApplicationServices())
        {
        }

        public SidebarViewModel(IApplicationServices services)
            : this(
                services.LibraryService,
                services.DocumentImportService,
                services.TagService,
                services.CollectionRepository,
                services.CollectionService,
                services.SettingsRepository,
                services.WatchFolderService,
                services.StorageUsageService,
                services.FilePickerService)
        {
        }

        public SidebarViewModel(
            ILibraryService libraryService,
            IDocumentImportService documentImportService,
            TagService tagService,
            ICollectionRepository collectionRepository,
            ICollectionService collectionService,
            IAppSettingsRepository settingsRepository,
            WatchFolderService watchFolderService,
            StorageUsageService storageUsageService,
            IFilePickerService filePickerService)
        {
            _libraryService = libraryService;
            _documentImportService = documentImportService;
            _tagService = tagService;
            _collectionRepository = collectionRepository;
            _collectionService = collectionService;
            _settingsRepository = settingsRepository;
            _watchFolderService = watchFolderService;
            _storageUsageService = storageUsageService;
            _filePickerService = filePickerService;
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

            foreach (var document in _libraryService.LoadDocuments())
            {
                Documents.Add(document);
            }

            foreach (var collection in _collectionRepository.LoadCollections())
            {
                Collections.Add(collection);
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
        private string _statusMessage = "Ready";

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

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasSelectedCollection))]
        private CollectionItem? _selectedCollection;

        public ObservableCollection<SidebarNavigationItem> NavigationItems { get; } = new();

        public ObservableCollection<SmartCollectionItem> SmartCollections { get; } = new();

        public ObservableCollection<TagItem> Tags { get; } = new();

        public ObservableCollection<CollectionItem> Collections { get; } = new();

        public ObservableCollection<DocumentItem> Documents { get; } = new();

        public ObservableCollection<DocumentItem> FilteredDocuments { get; } = new();

        public ObservableCollection<DocumentItem> SearchResultDocuments { get; } = new();

        public ObservableCollection<DocumentExplorerItem> DocumentExplorerItems { get; } = new();

        public int DocumentCount => FilteredDocuments.Count;

        public bool HasDocuments => Documents.Count > 0;

        public bool HasVisibleDocuments => FilteredDocuments.Count > 0;

        public bool HasSelectedDocument => SelectedDocument is not null;

        public bool HasSelectedCollection => SelectedCollection is not null;

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
            SelectedCollection is not null
                ? SelectedCollection.Name.ToUpperInvariant()
                : SelectedSmartCollection is not null
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
            !IsWatchFolderConfigured
                ? "Not configured"
                : Directory.Exists(WatchFolderPath)
                    ? $"Watching: {Path.GetFileName(WatchFolderPath)}"
                    : "Folder missing";

        public bool IsWatchFolderHealthy =>
            IsWatchFolderConfigured && Directory.Exists(WatchFolderPath);

        public string WatchFolderStateText =>
            !IsWatchFolderConfigured
                ? "Not configured"
                : IsWatchFolderHealthy
                    ? "Watching"
                    : "Folder missing";

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
            var result = _documentImportService.ImportDocument(filePath, Documents);
            StatusMessage = result.Message;

            if (!result.Succeeded || result.Value is null)
            {
                return;
            }

            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();

            SelectedDocument = result.Value.Document;
        }

        public void AddDocuments(IEnumerable<string> filePaths)
        {
            var imported = 0;
            var skipped = 0;
            var failed = 0;
            DocumentItem? lastDocument = null;

            foreach (var filePath in filePaths)
            {
                var result = _documentImportService.ImportDocument(filePath, Documents);

                if (!result.Succeeded || result.Value is null)
                {
                    failed++;
                    continue;
                }

                lastDocument = result.Value.Document;

                if (result.Value.Status == ImportDocumentStatus.SkippedDuplicate)
                {
                    skipped++;
                }
                else
                {
                    imported++;
                }
            }

            RebuildTags();
            ApplyDocumentFilter();
            ApplySearchFilter();

            if (lastDocument is not null)
            {
                SelectedDocument = lastDocument;
            }

            StatusMessage = $"Import finished: {imported} added, {skipped} skipped, {failed} failed.";
        }

        public void SetWatchFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                StatusMessage = "Choose an existing folder.";
                return;
            }

            WatchFolderPath = folderPath;

            var settings = _settingsRepository.LoadSettings();
            settings.WatchFolderPath = folderPath;
            _settingsRepository.SaveSettings(settings);

            _watchFolderService.Start(folderPath);
            StatusMessage = $"Watching {Path.GetFileName(folderPath)}.";
        }

        partial void OnWatchFolderPathChanged(string? value)
        {
            OnPropertyChanged(nameof(IsWatchFolderHealthy));
            OnPropertyChanged(nameof(WatchFolderStateText));
        }

        partial void OnSearchTextChanged(string value)
        {
            ApplySearchFilter();
        }

        partial void OnSelectedTagChanged(TagItem? value)
        {
            if (!_isRebuildingTags)
            {
                if (value is not null)
                {
                    SelectedCollection = null;
                }

                ApplyDocumentFilter();
            }
        }

        partial void OnSelectedSmartCollectionChanged(SmartCollectionItem? value)
        {
            if (value is not null)
            {
                SelectedNavigationItem = null;
                SelectedTag = null;
                SelectedCollection = null;
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

                _libraryService.MarkDocumentOpened(value, Documents);

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
                SelectedCollection = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        partial void OnSelectedCollectionChanged(CollectionItem? value)
        {
            if (value is not null)
            {
                SelectedNavigationItem = null;
                SelectedSmartCollection = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        [RelayCommand]
        private async Task ImportPdfFilesAsync()
        {
            var filePaths = await _filePickerService.PickPdfFilesAsync();
            AddDocuments(filePaths);
        }

        [RelayCommand]
        private async Task ConfigureWatchFolderAsync()
        {
            var folderPath = await _filePickerService.PickWatchFolderAsync();

            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                SetWatchFolder(folderPath);
            }
        }

        [RelayCommand]
        private void ToggleStar(DocumentItem? document)
        {
            if (document is null || document.IsDeleted)
            {
                return;
            }

            _libraryService.ToggleStar(document, Documents);
            RefreshAfterDocumentChange(rebuildTags: false);
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

            _tagService.AddTag(SelectedDocument, tag);

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

            _tagService.RemoveTag(SelectedDocument, tag);

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

            _libraryService.MoveToTrash(SelectedDocument, Documents);

            SelectedDocument = null;
            RefreshAfterDocumentChange();
        }

        [RelayCommand]
        private void RestoreSelectedDocument()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            _libraryService.Restore(SelectedDocument, Documents);

            SelectedDocument = null;
            RefreshAfterDocumentChange();
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

            _libraryService.DeleteForever(document, Documents);
            foreach (var collection in Collections)
            {
                _collectionService.RemoveDocumentFromCollection(document, collection);
            }
            SaveCollections();

            RefreshAfterDocumentChange();
        }

        [RelayCommand]
        private void CreateCollection()
        {
            var collection = _collectionService.CreateCollection("New Collection", Collections);

            Collections.Add(collection);
            SelectedCollection = collection;
            SaveCollections();
            StatusMessage = $"Created collection {collection.Name}.";
        }

        [RelayCommand]
        private void DeleteSelectedCollection()
        {
            if (SelectedCollection is null)
            {
                return;
            }

            var collection = SelectedCollection;
            SelectedCollection = null;
            _collectionService.DeleteCollection(collection, Collections);
            SaveCollections();
            ApplyDocumentFilter();
            StatusMessage = $"Deleted collection {collection.Name}.";
        }

        public event Action<DocumentItem>? OpenDocumentRequested;

        [RelayCommand]
        private void AddSelectedDocumentToCollection()
        {
            if (SelectedDocument is null || SelectedCollection is null)
            {
                return;
            }

            _collectionService.AddDocumentToCollection(SelectedDocument, SelectedCollection);
            SaveCollections();
            ApplyDocumentFilter();
            StatusMessage = $"Added to {SelectedCollection.Name}.";
        }

        [RelayCommand]
        private void RequestOpenDocument(DocumentItem? document)
        {
            if (document is null || document.IsDeleted)
            {
                return;
            }
            OpenDocumentRequested?.Invoke(document);
        }

        [RelayCommand]
        private void RemoveSelectedDocumentFromCollection()
        {
            if (SelectedDocument is null || SelectedCollection is null)
            {
                return;
            }

            _collectionService.RemoveDocumentFromCollection(SelectedDocument, SelectedCollection);
            SaveCollections();
            ApplyDocumentFilter();
            StatusMessage = $"Removed from {SelectedCollection.Name}.";
        }

        private void PersistDocumentsAndRefresh(bool rebuildTags = true)
        {
            _libraryService.SaveDocuments(Documents);

            RefreshAfterDocumentChange(rebuildTags);
        }

        public void RefreshAfterDocumentChange(bool rebuildTags = true)
        {
            if (rebuildTags)
            {
                RebuildTags();
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        private void SaveCollections()
        {
            _collectionRepository.SaveCollections(Collections);
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

            var documents = GetCurrentDocumentSource();

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

                foreach (var tag in _tagService.GetTagCounts(Documents))
                {
                    Tags.Add(new TagItem(tag.Name, tag.Count.ToString()));
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
            _currentFilteredDocuments = documents;
            RenderExplorerItems();
        }

        private void RenderExplorerItems()
        {
            DocumentExplorerItems.Clear();
            var groups = _currentFilteredDocuments
                .GroupBy(GetDocumentFolderName)
                .OrderBy(group => group.Key);

            foreach (var group in groups)
            {
                var folderName = group.Key;
                var isExpanded = IsFolderExpanded(folderName);
                DocumentExplorerItems.Add(DocumentExplorerItem.Folder(folderName, group.Count(), isExpanded));

                if (!isExpanded)
                {
                    continue;
                }

                if (!_folderStartIndices.TryGetValue(folderName, out var startIndex))
                {
                    startIndex = 0;
                    _folderStartIndices[folderName] = 0;
                }

                var files = group.Skip(startIndex).Take(_displayLimit).ToList();
                foreach (var document in files)
                {
                    DocumentExplorerItems.Add(DocumentExplorerItem.File(document));
                }
            }

            if (SelectedDocument != null && SelectedExplorerItem == null)
            {
                SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                    item.Document?.Id == SelectedDocument?.Id);
            }
        }

        [RelayCommand]
        private void ScrollDocuments(int direction)
        {
            var firstExpandedGroup = _currentFilteredDocuments
                .GroupBy(GetDocumentFolderName)
                .OrderBy(group => group.Key)
                .FirstOrDefault(g => IsFolderExpanded(g.Key));

            if (firstExpandedGroup == null) return;

            var folderName = firstExpandedGroup.Key;
            _folderStartIndices.TryGetValue(folderName, out var startIndex);

            startIndex += direction;

            if (startIndex > firstExpandedGroup.Count() - _displayLimit)
            {
                startIndex = firstExpandedGroup.Count() - _displayLimit;
            }

            if (startIndex < 0)
            {
                startIndex = 0;
            }

            _folderStartIndices[folderName] = startIndex;
            RenderExplorerItems();
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

            var documents = GetCurrentDocumentSource()
                .Where(document => _libraryService.MatchesSearch(document, query))
                .OrderBy(document => document.Title);

            foreach (var document in documents)
            {
                SearchResultDocuments.Add(document);
            }

            NotifyDocumentStateChanged();
        }

        private IEnumerable<DocumentItem> GetCurrentDocumentSource()
        {
            if (SelectedCollection is not null)
            {
                return _collectionService.GetDocumentsInCollection(
                    SelectedCollection,
                    Documents);
            }

            return _libraryService.ApplySmartCollectionFilter(
                _libraryService.GetNavigationDocuments(
                    Documents,
                    SelectedNavigationItem?.Name),
                SelectedSmartCollection?.Kind);
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
