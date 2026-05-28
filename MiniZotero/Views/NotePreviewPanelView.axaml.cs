using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.Helpers;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class NotePreviewPanelView : UserControl
    {
        public NotePreviewPanelView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object? sender, EventArgs e)
        {
            if (DataContext is NotePreviewPanelViewModel viewModel)
            {
                viewModel.TableInsertRequested -= OnTableInsertRequested;
                viewModel.TableInsertRequested += OnTableInsertRequested;
            }
        }

        private void OnTableInsertRequested(int rows, int cols)
        {
            TableButton.Flyout?.Hide();

            if (DataContext is not NotePreviewPanelViewModel viewModel ||
                viewModel.ActiveDocument is null)
            {
                return;
            }

            var selectionStart = Math.Min(NoteTextBox.SelectionStart, NoteTextBox.SelectionEnd);
            var selectionEnd = Math.Max(NoteTextBox.SelectionStart, NoteTextBox.SelectionEnd);
            var selectionLength = selectionEnd - selectionStart;
            
            var result = TextBoxMarkdownFormatter.ApplyTable(NoteTextBox.Text ?? string.Empty, selectionStart, selectionLength, rows, cols);

            NoteTextBox.Text = result.Text;
            NoteTextBox.SelectionStart = result.SelectionStart;
            NoteTextBox.SelectionEnd = result.SelectionStart + result.SelectionLength;
            NoteTextBox.Focus();
        }

        private void OnTableFlyoutOpened(object? sender, EventArgs e)
        {
            if (DataContext is NotePreviewPanelViewModel viewModel)
            {
                viewModel.ResetTableSelectionCommand.Execute(null);
            }
        }

        private void OnTableCellPointerEntered(object? sender, Avalonia.Input.PointerEventArgs e)
        {
            if (sender is Control control && control.DataContext is TableCellViewModel cell && DataContext is NotePreviewPanelViewModel viewModel)
            {
                viewModel.HoverTableCellCommand.Execute(cell);
            }
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

        private void OnHeadingClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyHeading);
        }

        private void OnBoldClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyBold);
        }

        private void OnItalicClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyItalic);
        }

        private void OnBulletListClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyBulletList);
        }

        private void OnQuoteClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyQuote);
        }

        private void OnLinkClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyLink);
        }

        private void OnNumberedListClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyNumberedList);
        }

        private void OnCodeClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyCode);
        }

        private void OnHorizontalRuleClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyHorizontalRule);
        }

        private void OnCheckboxListClicked(object? sender, RoutedEventArgs e)
        {
            ApplyMarkdownFormat(TextBoxMarkdownFormatter.ApplyCheckboxList);
        }

        private void ApplyMarkdownFormat(
            Func<string, int, int, MarkdownFormatResult> formatter)
        {
            if (DataContext is not NotePreviewPanelViewModel viewModel ||
                viewModel.ActiveDocument is null)
            {
                return;
            }

            var selectionStart = Math.Min(NoteTextBox.SelectionStart, NoteTextBox.SelectionEnd);
            var selectionEnd = Math.Max(NoteTextBox.SelectionStart, NoteTextBox.SelectionEnd);
            var selectionLength = selectionEnd - selectionStart;
            var result = formatter(NoteTextBox.Text ?? string.Empty, selectionStart, selectionLength);

            NoteTextBox.Text = result.Text;
            NoteTextBox.SelectionStart = result.SelectionStart;
            NoteTextBox.SelectionEnd = result.SelectionStart + result.SelectionLength;
            NoteTextBox.Focus();
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
