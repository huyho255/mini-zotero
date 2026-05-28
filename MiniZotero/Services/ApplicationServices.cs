using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public sealed class ApplicationServices : IApplicationServices
    {
        public ApplicationServices()
        {
            StorageService = new AppStorageService();
            var autoTagService = new AutoTagService();
            var markdownExportService = new MarkdownExportService();

            DocumentRepository = new DocumentRepository(StorageService, autoTagService);
            NoteRepository = new NoteRepository(StorageService);
            HighlightRepository = new HighlightRepository(StorageService);
            CollectionRepository = new CollectionRepository(StorageService);
            SettingsRepository = new AppSettingsRepository(StorageService);

            DocumentImportService = new DocumentImportService(DocumentRepository);
            NoteService = new NoteService(NoteRepository, markdownExportService);
            HighlightService = new HighlightService(HighlightRepository);
            LibraryService = new LibraryService(DocumentRepository, NoteService, DocumentImportService);
            CollectionService = new CollectionService();
            PdfService = new PdfService();
            FilePickerService = new FilePickerService();
            TagService = new TagService();
            WatchFolderService = new WatchFolderService();
            StorageUsageService = new StorageUsageService();
        }

        public AppStorageService StorageService { get; }

        public IDocumentRepository DocumentRepository { get; }

        public INoteRepository NoteRepository { get; }

        public IHighlightRepository HighlightRepository { get; }

        public ICollectionRepository CollectionRepository { get; }

        public IAppSettingsRepository SettingsRepository { get; }

        public ILibraryService LibraryService { get; }

        public IDocumentImportService DocumentImportService { get; }

        public INoteService NoteService { get; }

        public IHighlightService HighlightService { get; }

        public ICollectionService CollectionService { get; }

        public IPdfService PdfService { get; }

        public IFilePickerService FilePickerService { get; }

        public TagService TagService { get; }

        public WatchFolderService WatchFolderService { get; }

        public StorageUsageService StorageUsageService { get; }
    }
}
