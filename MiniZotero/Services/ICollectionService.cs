using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public interface ICollectionService
    {
        CollectionItem CreateCollection(string name, IEnumerable<CollectionItem> existingCollections);

        void RenameCollection(CollectionItem collection, string newName, IEnumerable<CollectionItem> existingCollections);

        void DeleteCollection(CollectionItem collection, ICollection<CollectionItem> collections);

        void AddDocumentToCollection(DocumentItem document, CollectionItem collection);

        void RemoveDocumentFromCollection(DocumentItem document, CollectionItem collection);

        IEnumerable<DocumentItem> GetDocumentsInCollection(
            CollectionItem collection,
            IEnumerable<DocumentItem> documents);
    }
}
