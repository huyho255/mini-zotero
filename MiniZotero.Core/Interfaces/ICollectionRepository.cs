using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface ICollectionRepository
{
    void Add(Collection collection);

    void Update(Collection collection);

    void Delete(Guid id);

    Collection? GetById(Guid id);

    List<Collection> GetAll();
}