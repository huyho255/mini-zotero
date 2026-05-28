using System;
using System.Collections.Generic;
using System.Linq;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class TagService
    {
        public bool AddTag(DocumentItem document, string tag)
        {
            var normalizedTag = NormalizeTag(tag);

            if (string.IsNullOrWhiteSpace(normalizedTag))
            {
                return false;
            }

            document.Tags ??= [];

            var exists = document.Tags.Any(existingTag =>
                string.Equals(existingTag, normalizedTag, StringComparison.OrdinalIgnoreCase));

            if (exists)
            {
                return false;
            }

            document.Tags.Add(normalizedTag);
            return true;
        }

        public bool RemoveTag(DocumentItem document, string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                return false;
            }

            return document.Tags.RemoveAll(existingTag =>
                string.Equals(existingTag, tag.Trim(), StringComparison.OrdinalIgnoreCase)) > 0;
        }

        public IReadOnlyList<(string Name, int Count)> GetTagCounts(IEnumerable<DocumentItem> documents)
        {
            return documents
                .Where(document => !document.IsDeleted)
                .SelectMany(document => document.Tags)
                .Where(tag => !string.IsNullOrWhiteSpace(tag))
                .GroupBy(tag => tag.Trim(), StringComparer.OrdinalIgnoreCase)
                .OrderBy(group => group.Key)
                .Select(group => (group.Key, group.Count()))
                .ToList();
        }

        private static string NormalizeTag(string tag)
        {
            return tag.Trim();
        }
    }
}
