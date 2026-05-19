using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Infrastructure.Repositories;

public class CollectionRepository : ICollectionRepository
{
    private readonly List<Collection> _collections = new();

    public void Add(Collection collection)
    {
        _collections.Add(collection);
    }

    public void Update(Collection collection)
    {
        Collection? existingCollection = GetById(collection.Id);

        if (existingCollection == null)
        {
            return;
        }

        existingCollection.Name = collection.Name;
        existingCollection.Documents = collection.Documents;
    }

    public void Delete(Guid id)
    {
        Collection? collection = GetById(id);

        if (collection != null)
        {
            _collections.Remove(collection);
        }
    }

    public Collection? GetById(Guid id)
    {
        return _collections.FirstOrDefault(c => c.Id == id);
    }

    public List<Collection> GetAll()
    {
        return _collections;
    }
}