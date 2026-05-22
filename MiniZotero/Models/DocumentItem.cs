using System;
using System.Collections.Generic;

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
            int lastReadPage,
            int lastZoomPercent = 120,
            bool isStarred = false)
        {
            Id = id;
            Title = title;
            FilePath = filePath;
            OriginalFilePath = originalFilePath;
            AddedAt = addedAt;
            LastOpenedAt = lastOpenedAt;
            LastReadPage = lastReadPage;
            LastZoomPercent = lastZoomPercent;
            IsStarred = isStarred;
        }

        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string OriginalFilePath { get; set; } = string.Empty;

        public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? LastOpenedAt { get; set; }

        public int LastReadPage { get; set; } = 1;

        public int LastZoomPercent { get; set; } = 120;

        public bool IsStarred { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }

        public List<string> Tags { get; set; } = [];
    }
}
