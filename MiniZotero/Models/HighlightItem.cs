using System;
using System.Collections.Generic;

namespace MiniZotero.Models
{
    public sealed class HighlightItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        public string DocumentId { get; set; } = string.Empty;

        public int PageNumber { get; set; } = 1;

        public string Text { get; set; } = string.Empty;

        public string Color { get; set; } = "yellow";

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public List<HighlightRect> Rects { get; set; } = [];
    }
}
