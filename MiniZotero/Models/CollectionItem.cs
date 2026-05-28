using System;
using System.Collections.Generic;

namespace MiniZotero.Models
{
    public sealed class CollectionItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        public string Name { get; set; } = "New Collection";

        public List<string> DocumentIds { get; set; } = [];

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.Now;
    }
}
