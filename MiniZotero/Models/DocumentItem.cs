using System;

namespace MiniZotero.Models
{
    public sealed class DocumentItem
    {
        public DocumentItem()
        {
        }

        public DocumentItem(
            string id,
            string title,
            string filePath,
            string originalFilePath,
            DateTimeOffset addedAt,
            DateTimeOffset? lastOpenedAt,
            int lastReadPage)
        {
            Id = id;
            Title = title;
            FilePath = filePath;
            OriginalFilePath = originalFilePath;
            AddedAt = addedAt;
            LastOpenedAt = lastOpenedAt;
            LastReadPage = lastReadPage;
        }

        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string OriginalFilePath { get; set; } = string.Empty;

        public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? LastOpenedAt { get; set; }

        public int LastReadPage { get; set; } = 1;
    }
}
