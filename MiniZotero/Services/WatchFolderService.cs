using System;
using System.IO;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public sealed class WatchFolderService : IDisposable
    {
        private FileSystemWatcher? _watcher;

        public event Action<string>? PdfDetected;

        public string? FolderPath { get; private set; }

        public bool IsWatching => _watcher is not null;

        public void Start(string folderPath)
        {
            Stop();

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return;
            }

            FolderPath = folderPath;

            _watcher = new FileSystemWatcher(folderPath)
            {
                Filter = "*.pdf",
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size
            };

            _watcher.Created += OnPdfCreated;
            _watcher.Renamed += OnPdfRenamed;
            _watcher.EnableRaisingEvents = true;

            ImportExistingPdfs(folderPath);
        }

        public void Stop()
        {
            if (_watcher is null)
            {
                return;
            }

            _watcher.EnableRaisingEvents = false;
            _watcher.Created -= OnPdfCreated;
            _watcher.Renamed -= OnPdfRenamed;
            _watcher.Dispose();
            _watcher = null;
        }

        private void ImportExistingPdfs(string folderPath)
        {
            foreach (var filePath in Directory.EnumerateFiles(folderPath, "*.pdf"))
            {
                _ = NotifyWhenReadyAsync(filePath);
            }
        }

        private void OnPdfCreated(object sender, FileSystemEventArgs e)
        {
            _ = NotifyWhenReadyAsync(e.FullPath);
        }

        private void OnPdfRenamed(object sender, RenamedEventArgs e)
        {
            _ = NotifyWhenReadyAsync(e.FullPath);
        }

        private async Task NotifyWhenReadyAsync(string filePath)
        {
            if (!filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var isReady = await WaitUntilFileReadyAsync(filePath);

            if (isReady)
            {
                PdfDetected?.Invoke(filePath);
            }
        }

        private static async Task<bool> WaitUntilFileReadyAsync(string filePath)
        {
            for (var attempt = 0; attempt < 20; attempt++)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        return false;
                    }

                    using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    return stream.Length > 0;
                }
                catch (IOException)
                {
                    await Task.Delay(300);
                }
                catch (UnauthorizedAccessException)
                {
                    await Task.Delay(300);
                }
            }

            return false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
