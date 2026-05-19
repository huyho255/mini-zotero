using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly List<Tag> _tags = new();

    public void Add(Tag tag)
    {
        bool exists = _tags.Any(t =>
            t.Name.Equals(tag.Name, StringComparison.OrdinalIgnoreCase));

        if (!exists)
        {
            _tags.Add(tag);
        }
    }

    public void Delete(Guid id)
    {
        Tag? tag = GetById(id);

        if (tag != null)
        {
            _tags.Remove(tag);
        }
    }

    public Tag? GetById(Guid id)
    {
        return _tags.FirstOrDefault(t => t.Id == id);
    }

    public Tag? GetByName(string name)
    {
        return _tags.FirstOrDefault(t =>
            t.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Tag> GetAll()
    {
        return _tags;
    }
}