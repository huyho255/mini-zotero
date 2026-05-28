using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public interface IApplicationServices
    {
        AppStorageService StorageService { get; }

        IDocumentRepository DocumentRepository { get; }

        INoteRepository NoteRepository { get; }

        IHighlightRepository HighlightRepository { get; }

        ICollectionRepository CollectionRepository { get; }

        IAppSettingsRepository SettingsRepository { get; }

        ILibraryService LibraryService { get; }

        IDocumentImportService DocumentImportService { get; }

        INoteService NoteService { get; }

        IHighlightService HighlightService { get; }

        ICollectionService CollectionService { get; }

        IPdfService PdfService { get; }

        IFilePickerService FilePickerService { get; }

        TagService TagService { get; }

        WatchFolderService WatchFolderService { get; }

        StorageUsageService StorageUsageService { get; }
    }
}
