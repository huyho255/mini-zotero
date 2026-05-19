using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface INoteRepository
{
    void Add(Note note);

    void Update(Note note);

    void Delete(Guid id);

    Note? GetById(Guid id);

    List<Note> GetByDocumentId(Guid documentId);
}