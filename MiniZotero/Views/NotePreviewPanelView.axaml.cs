using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class NotePreviewPanelView : UserControl
    {
        public NotePreviewPanelView()
        {
            InitializeComponent();
        }

        private async void OnExportMarkdownClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);

            if (topLevel is null || DataContext is not NotePreviewPanelViewModel viewModel)
            {
                return;
            }

            var documentTitle = viewModel.ActiveDocument?.Title ?? "MiniZotero Notes";
            var safeFileName = MakeSafeFileName(documentTitle);

            var file = await topLevel.StorageProvider.SaveFilePickerAsync(
                new FilePickerSaveOptions
                {
                    Title = "Export notes and highlights",
                    SuggestedFileName = $"{safeFileName}.md",
                    FileTypeChoices =
                    [
                        new FilePickerFileType("Markdown")
                        {
                            Patterns = ["*.md"],
                            MimeTypes = ["text/markdown", "text/plain"]
                        }
                    ]
                });

            if (file is null)
            {
                return;
            }

            var outputPath = Uri.UnescapeDataString(file.Path.LocalPath);

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return;
            }

            viewModel.ExportActiveDocumentToMarkdown(outputPath);
        }

        private static string MakeSafeFileName(string value)
        {
            var invalidCharacters = System.IO.Path.GetInvalidFileNameChars();

            var safe = new string(value
                .Select(character => invalidCharacters.Contains(character) ? '_' : character)
                .ToArray());

            return string.IsNullOrWhiteSpace(safe)
                ? "MiniZotero Notes"
                : safe.Trim();
        }
    }
}
