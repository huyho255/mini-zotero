using System;

namespace MiniZotero.Models
{
    public sealed class DocumentItem
    {
        public DocumentItem(string id, string title, string filePath, DateTimeOffset addedAt)
        {
            Id = id;
            Title = title;
            FilePath = filePath;
            AddedAt = addedAt;
        }

        public string Id { get; }

        public string Title { get; }

        public string FilePath { get; }

        public DateTimeOffset AddedAt { get; }
    }
}
