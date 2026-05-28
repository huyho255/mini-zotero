using System;
using System.Linq;

namespace MiniZotero.Helpers
{
    public static class TextBoxMarkdownFormatter
    {
        public static MarkdownFormatResult ApplyBold(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return WrapInline(text, selectionStart, selectionLength, "**", "**", "bold text");
        }

        public static MarkdownFormatResult ApplyItalic(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return WrapInline(text, selectionStart, selectionLength, "*", "*", "italic text");
        }

        public static MarkdownFormatResult ApplyLink(
            string text,
            int selectionStart,
            int selectionLength)
        {
            text ??= string.Empty;
            var range = GetSelectedRange(text, selectionStart, selectionLength);

            var selectedText = range.Length == 0 ? "link text" : text.Substring(range.Start, range.Length);
            var replacement = $"[{selectedText}](https://)";
            var newText = text.Remove(range.Start, range.Length)
                .Insert(range.Start, replacement);
            var urlStart = range.Start + selectedText.Length + 3;

            return new MarkdownFormatResult(newText, urlStart, "https://".Length);
        }

        public static MarkdownFormatResult ApplyHeading(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return PrefixSelectedLines(text, selectionStart, selectionLength, "## ");
        }

        public static MarkdownFormatResult ApplyBulletList(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return PrefixSelectedLines(text, selectionStart, selectionLength, "- ");
        }

        public static MarkdownFormatResult ApplyQuote(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return PrefixSelectedLines(text, selectionStart, selectionLength, "> ");
        }

        public static MarkdownFormatResult ApplyNumberedList(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return PrefixSelectedLines(text, selectionStart, selectionLength, "1. ");
        }

        public static MarkdownFormatResult ApplyCheckboxList(
            string text,
            int selectionStart,
            int selectionLength)
        {
            return PrefixSelectedLines(text, selectionStart, selectionLength, "- [ ] ");
        }

        public static MarkdownFormatResult ApplyCode(
            string text,
            int selectionStart,
            int selectionLength)
        {
            text ??= string.Empty;
            var range = GetSelectedRange(text, selectionStart, selectionLength);

            if (range.Length == 0)
            {
                var placeholder = "code";
                var prefix0 = "`";
                var suffix0 = "`";
                var insertText = $"{prefix0}{placeholder}{suffix0}";
                var newText0 = text.Insert(range.Start, insertText);
                return new MarkdownFormatResult(newText0, range.Start + prefix0.Length, placeholder.Length);
            }

            var selectedText = text.Substring(range.Start, range.Length);
            var isMultiline = selectedText.Contains('\n', StringComparison.Ordinal);
            var prefix = isMultiline ? "```\n" : "`";
            var suffix = isMultiline ? "\n```" : "`";
            var replacement = $"{prefix}{selectedText}{suffix}";
            var newText = text.Remove(range.Start, range.Length)
                .Insert(range.Start, replacement);

            return new MarkdownFormatResult(newText, range.Start + prefix.Length, selectedText.Length);
        }

        public static MarkdownFormatResult ApplyHorizontalRule(
            string text,
            int selectionStart,
            int selectionLength)
        {
            text ??= string.Empty;
            selectionStart = Math.Clamp(selectionStart, 0, text.Length);

            var prefix = selectionStart > 0 && text[selectionStart - 1] != '\n' ? "\n" : string.Empty;
            var suffix = selectionStart < text.Length && text[selectionStart] != '\n' ? "\n" : string.Empty;
            var insertion = $"{prefix}---{suffix}";
            var newText = text.Insert(selectionStart, insertion);

            return new MarkdownFormatResult(newText, selectionStart + insertion.Length, 0);
        }

        public static MarkdownFormatResult ApplyTable(
            string text,
            int selectionStart,
            int selectionLength,
            int rows,
            int cols)
        {
            text ??= string.Empty;
            selectionStart = Math.Clamp(selectionStart, 0, text.Length);

            var prefix = selectionStart > 0 && text[selectionStart - 1] != '\n' ? "\n" : string.Empty;
            var suffix = selectionStart < text.Length && text[selectionStart] != '\n' ? "\n" : string.Empty;
            
            var sb = new System.Text.StringBuilder();
            
            sb.Append("|");
            for (int c = 1; c <= cols; c++)
            {
                sb.Append($" Header {c} |");
            }
            sb.AppendLine();
            
            sb.Append("|");
            for (int c = 1; c <= cols; c++)
            {
                sb.Append(" -------- |");
            }
            
            for (int r = 1; r < rows; r++)
            {
                sb.AppendLine();
                sb.Append("|");
                for (int c = 1; c <= cols; c++)
                {
                    sb.Append($" Cell {r}-{c}   |");
                }
            }

            var tableTemplate = sb.ToString();

            var insertion = $"{prefix}{tableTemplate}{suffix}";
            var newText = text.Insert(selectionStart, insertion);

            return new MarkdownFormatResult(newText, selectionStart + prefix.Length + 2, 8);
        }

        private static MarkdownFormatResult WrapInline(
            string text,
            int selectionStart,
            int selectionLength,
            string prefix,
            string suffix,
            string placeholder)
        {
            text ??= string.Empty;
            var range = GetSelectedRange(text, selectionStart, selectionLength);

            if (range.Length == 0)
            {
                var insertText = $"{prefix}{placeholder}{suffix}";
                var newText0 = text.Insert(range.Start, insertText);
                return new MarkdownFormatResult(
                    newText0,
                    range.Start + prefix.Length,
                    placeholder.Length);
            }

            var selectedText = text.Substring(range.Start, range.Length);
            var replacement = $"{prefix}{selectedText}{suffix}";
            var newText = text.Remove(range.Start, range.Length)
                .Insert(range.Start, replacement);

            return new MarkdownFormatResult(
                newText,
                range.Start + prefix.Length,
                selectedText.Length);
        }

        private static TextRange GetSelectedRange(
            string text,
            int selectionStart,
            int selectionLength)
        {
            selectionStart = Math.Clamp(selectionStart, 0, text.Length);
            selectionLength = Math.Clamp(selectionLength, 0, text.Length - selectionStart);

            return new TextRange(selectionStart, selectionLength);
        }

        private static MarkdownFormatResult PrefixSelectedLines(
            string text,
            int selectionStart,
            int selectionLength,
            string prefix)
        {
            text ??= string.Empty;
            selectionStart = Math.Clamp(selectionStart, 0, text.Length);
            selectionLength = Math.Clamp(selectionLength, 0, text.Length - selectionStart);

            if (text.Length == 0)
            {
                return new MarkdownFormatResult(prefix, prefix.Length, 0);
            }

            var lineStart = text.LastIndexOf('\n', Math.Max(selectionStart - 1, 0));
            lineStart = lineStart < 0 ? 0 : lineStart + 1;

            var selectionEnd = selectionStart + selectionLength;
            var lineEnd = selectionLength == 0
                ? GetLineEnd(text, selectionStart)
                : GetLineEnd(text, Math.Max(selectionEnd - 1, 0));

            var block = text.Substring(lineStart, lineEnd - lineStart);
            var normalizedBlock = block.Replace("\r\n", "\n");
            var lines = normalizedBlock.Split('\n');
            var newBlock = string.Join('\n', lines.Select(line => PrefixLine(line, prefix)));

            if (block.Contains("\r\n", StringComparison.Ordinal))
            {
                newBlock = newBlock.Replace("\n", "\r\n");
            }

            var newText = text.Remove(lineStart, lineEnd - lineStart)
                .Insert(lineStart, newBlock);
            var addedLength = newBlock.Length - block.Length;

            return new MarkdownFormatResult(
                newText,
                Math.Min(selectionStart + addedLength, newText.Length),
                Math.Max(0, selectionLength + addedLength));
        }

        private static string PrefixLine(string line, string prefix)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                return line;
            }

            var leadingWhitespaceLength = line.Length - line.TrimStart().Length;
            var leadingWhitespace = line[..leadingWhitespaceLength];
            var content = line[leadingWhitespaceLength..];

            return content.StartsWith(prefix, StringComparison.Ordinal)
                ? line
                : $"{leadingWhitespace}{prefix}{content}";
        }

        private static MarkdownFormatResult KeepSelection(
            string text,
            int selectionStart,
            int selectionLength)
        {
            selectionStart = Math.Clamp(selectionStart, 0, text.Length);
            selectionLength = Math.Clamp(selectionLength, 0, text.Length - selectionStart);

            return new MarkdownFormatResult(text, selectionStart, selectionLength);
        }

        private static int GetLineEnd(string text, int index)
        {
            var lineEnd = text.IndexOf('\n', Math.Clamp(index, 0, text.Length));
            return lineEnd < 0 ? text.Length : lineEnd;
        }

        private readonly record struct TextRange(int Start, int Length);
    }

    public sealed record MarkdownFormatResult(
        string Text,
        int SelectionStart,
        int SelectionLength);
}
