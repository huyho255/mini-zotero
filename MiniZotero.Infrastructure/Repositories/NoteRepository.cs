using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Infrastructure.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly List<Note> _notes = new();

    public void Add(Note note)
    {
        _notes.Add(note);
    }

    public void Update(Note note)
    {
        Note? existingNote = GetById(note.Id);

        if (existingNote == null)
        {
            return;
        }

        existingNote.MarkdownContent = note.MarkdownContent;
        existingNote.UpdatedAt = DateTime.Now;
    }

    public void Delete(Guid id)
    {
        Note? note = GetById(id);

        if (note != null)
        {
            _notes.Remove(note);
        }
    }

    public Note? GetById(Guid id)
    {
        return _notes.FirstOrDefault(n => n.Id == id);
    }

    public List<Note> GetByDocumentId(Guid documentId)
    {
        return _notes
            .Where(n => n.DocumentId == documentId)
            .ToList();
    }
}