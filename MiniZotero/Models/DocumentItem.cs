using System;

namespace MiniZotero.Models
{
    public sealed class DocumentItem
    {
        public DocumentItem(string title, string filePath)
        {
            Title = title;
            FilePath = filePath;
            AddedAt = DateTimeOffset.Now;
        }

        public string Title { get; }

        public string FilePath { get; }

        public DateTimeOffset AddedAt { get; }
    }
}
