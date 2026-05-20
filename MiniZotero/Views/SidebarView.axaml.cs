using System.Linq;
using Avalonia.Controls;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views;

public partial class SidebarView : UserControl
{
    private static readonly FilePickerFileType PdfFileType = new("PDF Documents")
    {
        Patterns = new[] { "*.pdf" },
        MimeTypes = new[] { "application/pdf" }
    };

    public SidebarView()
    {
        InitializeComponent();
    }

    private async void OnImportPdfClicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var topLevel = TopLevel.GetTopLevel(this);

        if (topLevel is null)
        {
            return;
        }

        var files = await topLevel.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Import PDF",
                AllowMultiple = false,
                FileTypeFilter = new[] { PdfFileType }
            });

        var selectedFile = files.FirstOrDefault();

        if (selectedFile is null)
        {
            return;
        }

        string? localPath = selectedFile.TryGetLocalPath();

        if (string.IsNullOrWhiteSpace(localPath))
        {
            return;
        }

        if (DataContext is SidebarViewModel viewModel)
        {
            viewModel.AddDocumentFromFile(localPath);
        }
    }
}
