using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
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

            Sidebar = new SidebarViewModel(
                documentRepository,
                settingsRepository,
                watchFolderService,
                storageUsageService);
            Notes = new NotePreviewPanelViewModel(
                noteRepository,
                highlightRepository,
                markdownExportService);
            Workspace = new TabWorkspaceViewModel(document =>
                documentRepository.SaveDocuments(Sidebar.Documents));

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
