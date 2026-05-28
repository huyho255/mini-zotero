using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class MarkdownExportService
    {
        public void ExportDocumentNotes(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights,
            string outputPath)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return;
            }

            var markdown = BuildMarkdown(document, noteText, highlights);
            File.WriteAllText(outputPath, markdown, Encoding.UTF8);
        }

        private static string BuildMarkdown(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"# {document.Title}");
            builder.AppendLine();
            builder.AppendLine("## Document");
            builder.AppendLine();
            builder.AppendLine($"- File: `{document.FilePath}`");
            builder.AppendLine($"- Original: `{document.OriginalFilePath}`");
            builder.AppendLine($"- Added: {document.AddedAt:yyyy-MM-dd HH:mm}");
            builder.AppendLine($"- Last page: {document.LastReadPage}");
            builder.AppendLine();

            builder.AppendLine("## Notes");
            builder.AppendLine();

            if (string.IsNullOrWhiteSpace(noteText))
            {
                builder.AppendLine("_No notes yet._");
            }
            else
            {
                builder.AppendLine(noteText.Trim());
            }

            builder.AppendLine();
            builder.AppendLine("## Highlights");
            builder.AppendLine();

            var orderedHighlights = highlights
                .OrderBy(highlight => highlight.PageNumber)
                .ThenBy(highlight => highlight.CreatedAt)
                .ToList();

            if (orderedHighlights.Count == 0)
            {
                builder.AppendLine("_No highlights yet._");
                return builder.ToString();
            }

            foreach (var highlight in orderedHighlights)
            {
                builder.AppendLine($"### Page {highlight.PageNumber}");
                builder.AppendLine();
                builder.AppendLine($"> {NormalizeQuote(highlight.Text)}");
                builder.AppendLine();
                builder.AppendLine($"- Created: {highlight.CreatedAt:yyyy-MM-dd HH:mm}");
                builder.AppendLine($"- Highlight Id: `{highlight.Id}`");
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private static string NormalizeQuote(string? text)
        {
            return (text ?? string.Empty)
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Replace("\n", "\n> ")
                .Trim();
        }
    }
}
