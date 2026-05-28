using System;
using System.Collections.Generic;
using System.Linq;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class CollectionService : ICollectionService
    {
        public CollectionItem CreateCollection(
            string name,
            IEnumerable<CollectionItem> existingCollections)
        {
            var collectionName = GetAvailableName(
                string.IsNullOrWhiteSpace(name) ? "New Collection" : name.Trim(),
                existingCollections);

            return new CollectionItem
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = collectionName,
                CreatedAt = DateTimeOffset.Now,
                UpdatedAt = DateTimeOffset.Now
            };
        }

        public void RenameCollection(
            CollectionItem collection,
            string newName,
            IEnumerable<CollectionItem> existingCollections)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                return;
            }

            collection.Name = GetAvailableName(
                newName.Trim(),
                existingCollections.Where(item => item.Id != collection.Id));
            collection.UpdatedAt = DateTimeOffset.Now;
        }

        public void DeleteCollection(CollectionItem collection, ICollection<CollectionItem> collections)
        {
            collections.Remove(collection);
        }

        public void AddDocumentToCollection(DocumentItem document, CollectionItem collection)
        {
            if (string.IsNullOrWhiteSpace(document.Id) ||
                collection.DocumentIds.Any(id => string.Equals(id, document.Id, StringComparison.OrdinalIgnoreCase)))
            {
                return;
            }

            collection.DocumentIds.Add(document.Id);
            collection.UpdatedAt = DateTimeOffset.Now;
        }

        public void RemoveDocumentFromCollection(DocumentItem document, CollectionItem collection)
        {
            collection.DocumentIds.RemoveAll(id =>
                string.Equals(id, document.Id, StringComparison.OrdinalIgnoreCase));
            collection.UpdatedAt = DateTimeOffset.Now;
        }

        public IEnumerable<DocumentItem> GetDocumentsInCollection(
            CollectionItem collection,
            IEnumerable<DocumentItem> documents)
        {
            var documentIds = collection.DocumentIds.ToHashSet(StringComparer.OrdinalIgnoreCase);

            return documents
                .Where(document => !document.IsDeleted && documentIds.Contains(document.Id))
                .OrderBy(document => document.Title);
        }

        private static string GetAvailableName(
            string requestedName,
            IEnumerable<CollectionItem> existingCollections)
        {
            var names = existingCollections
                .Select(collection => collection.Name)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            if (!names.Contains(requestedName))
            {
                return requestedName;
            }

            var index = 2;
            string candidate;

            do
            {
                candidate = $"{requestedName} {index}";
                index++;
            }
            while (names.Contains(candidate));

            return candidate;
        }
    }
}
