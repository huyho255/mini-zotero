using MiniZotero.Core.Interfaces;

namespace MiniZotero.Core.Services;

public class WatchFolderService : IWatchFolderService
{
    private readonly IDocumentService _documentService;
    private FileSystemWatcher? _watcher;

    public bool IsWatching { get; private set; }

    public WatchFolderService(IDocumentService documentService)
    {
        _documentService = documentService;
    }

    public void StartWatching(string folderPath)
    {
        if (string.IsNullOrWhiteSpace(folderPath))
        {
            throw new ArgumentException("Folder path is empty.");
        }

        if (!Directory.Exists(folderPath))
        {
            throw new DirectoryNotFoundException(folderPath);
        }

        _watcher = new FileSystemWatcher(folderPath);

        _watcher.Created += OnFileCreated;
        _watcher.EnableRaisingEvents = true;

        IsWatching = true;
    }

    public void StopWatching()
    {
        if (_watcher != null)
        {
            _watcher.Created -= OnFileCreated;
            _watcher.Dispose();
            _watcher = null;
        }

        IsWatching = false;
    }

    private void OnFileCreated(object sender, FileSystemEventArgs e)
    {
        string extension = Path.GetExtension(e.FullPath).ToLower();

        if (extension != ".pdf" && extension != ".epub")
        {
            return;
        }

        try
        {
            Thread.Sleep(500);
            _documentService.ImportDocument(e.FullPath);
        }
        catch
        {
            // Tạm thời bỏ qua lỗi.
            // Sau này có thể ghi log hoặc hiện thông báo cho user.
        }
    }
}