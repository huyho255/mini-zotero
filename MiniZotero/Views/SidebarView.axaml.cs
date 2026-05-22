using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class SidebarView : UserControl
    {
        public SidebarView()
        {
            InitializeComponent();
        }

        private async void OnImportPdfClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null || DataContext is not SidebarViewModel viewModel)
            {
                return;
            }

            var pdfFiles = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
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

            foreach (var file in pdfFiles.Where(file => file.Path.IsFile))
            {
                viewModel.AddDocument(Uri.UnescapeDataString(file.Path.LocalPath));
            }
        }

        private async void OnConfigureWatchFolderClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null || DataContext is not SidebarViewModel viewModel)
            {
                return;
            }

            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(
                new FolderPickerOpenOptions
                {
                    Title = "Choose Watch Folder",
                    AllowMultiple = false
                });

            var folder = folders.FirstOrDefault();
            var folderPath = folder is null
                ? string.Empty
                : Uri.UnescapeDataString(folder.Path.LocalPath);

            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                viewModel.SetWatchFolder(folderPath);
            }
        }
    }
}
