using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface ITagRepository
{
    void Add(Tag tag);

    void Delete(Guid id);

    Tag? GetById(Guid id);

    Tag? GetByName(string name);

    List<Tag> GetAll();
}