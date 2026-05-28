using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;

namespace MiniZotero.Services
{
    public sealed class FilePickerService : IFilePickerService
    {
        public async Task<IReadOnlyList<string>> PickPdfFilesAsync()
        {
            var topLevel = GetMainTopLevel();
            if (topLevel is null)
            {
                return [];
            }

            var files = await topLevel.StorageProvider.OpenFilePickerAsync(
                new FilePickerOpenOptions
                {
                    Title = "Import PDF",
                    AllowMultiple = true,
                    FileTypeFilter =
                    [
                        new FilePickerFileType("PDF documents")
                        {
                            Patterns = ["*.pdf"],
                            MimeTypes = ["application/pdf"]
                        }
                    ]
                });

            return files
                .Where(file => file.Path.IsFile)
                .Select(file => Uri.UnescapeDataString(file.Path.LocalPath))
                .ToList();
        }

        public async Task<string?> PickWatchFolderAsync()
        {
            var topLevel = GetMainTopLevel();
            if (topLevel is null)
            {
                return null;
            }

            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(
                new FolderPickerOpenOptions
                {
                    Title = "Choose Watch Folder",
                    AllowMultiple = false
                });

            var folder = folders.FirstOrDefault();
            return folder is null
                ? null
                : Uri.UnescapeDataString(folder.Path.LocalPath);
        }

        private static TopLevel? GetMainTopLevel()
        {
            return Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop
                ? desktop.MainWindow
                : null;
        }
    }
}
