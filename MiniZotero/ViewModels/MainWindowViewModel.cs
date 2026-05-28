using MiniZotero.Repositories;
using MiniZotero.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string _statusMessage = "Ready";

        public MainWindowViewModel()
        {
            var storageService = new AppStorageService();
            var autoTagService = new AutoTagService();
            var documentRepository = new DocumentRepository(storageService, autoTagService);
            var noteRepository = new NoteRepository(storageService);
            var highlightRepository = new HighlightRepository(storageService);
            var settingsRepository = new AppSettingsRepository(storageService);
            var watchFolderService = new WatchFolderService();
            var markdownExportService = new MarkdownExportService();
            var storageUsageService = new StorageUsageService();
            var noteService = new NoteService(noteRepository, markdownExportService);
            var highlightService = new HighlightService(highlightRepository);
            var libraryService = new LibraryService(documentRepository, noteService);
            var tagService = new TagService();

            Sidebar = new SidebarViewModel(
                libraryService,
                tagService,
                settingsRepository,
                watchFolderService,
                storageUsageService);
            Notes = new NotePreviewPanelViewModel(
                noteService,
                highlightService);
            Workspace = new TabWorkspaceViewModel(document =>
                libraryService.SaveDocuments(Sidebar.Documents));

            Workspace.PdfViewer.HighlightCreated += (text, pageNumber, rects) =>
            {
                Notes.AddHighlightFromViewer(text, pageNumber, rects);
            };

            Notes.HighlightsChanged += () =>
            {
                Workspace.PdfViewer.LoadHighlightsIntoViewer(Notes.Highlights);
            };

            Notes.HighlightSelected += highlight =>
            {
                Workspace.PdfViewer.NavigateToHighlight(highlight);
            };

            Notes.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(NotePreviewPanelViewModel.StatusMessage))
                {
                    StatusMessage = Notes.StatusMessage;
                }
            };

            Workspace.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(TabWorkspaceViewModel.ActiveDocument))
                {
                    OnPropertyChanged(nameof(OpenDocumentCount));
                    OnPropertyChanged(nameof(DocumentsOpenText));
                }
            };

            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.StatusMessage))
                {
                    StatusMessage = Sidebar.StatusMessage;
                }

                if (e.PropertyName == nameof(SidebarViewModel.SelectedDocument) &&
                    Sidebar.SelectedDocument is { } document)
                {
                    Workspace.OpenDocument(document);
                    Notes.OpenDocument(document);
                    Workspace.PdfViewer.LoadHighlightsIntoViewer(Notes.Highlights);
                }
            };
        }

        public SidebarViewModel Sidebar { get; }

        public TabWorkspaceViewModel Workspace { get; }

        public NotePreviewPanelViewModel Notes { get; }

        public int OpenDocumentCount => Workspace.ActiveDocument is null ? 0 : 1;

        public string DocumentsOpenText =>
            OpenDocumentCount == 1
                ? "1 document open"
                : $"{OpenDocumentCount} documents open";

        public string LibraryStatusText => "Local library";

    }
}
