using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Repositories
{
    public interface ICollectionRepository
    {
        IReadOnlyList<CollectionItem> LoadCollections();

        void SaveCollections(IEnumerable<CollectionItem> collections);
    }
}
