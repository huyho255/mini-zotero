using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Infrastructure.Repositories;

public class DocumentRepository : IDocumentRepository
{
    private readonly List<Document> _documents = new();

    public void Add(Document document)
    {
        _documents.Add(document);
    }

    public void Update(Document document)
    {
        Document? existingDocument = GetById(document.Id);

        if (existingDocument == null)
        {
            return;
        }

        existingDocument.Title = document.Title;
        existingDocument.FilePath = document.FilePath;
        existingDocument.FileType = document.FileType;
        existingDocument.ImportedAt = document.ImportedAt;
        existingDocument.Authors = document.Authors;
        existingDocument.Tags = document.Tags;
        existingDocument.Notes = document.Notes;
    }

    public void Delete(Guid id)
    {
        Document? document = GetById(id);

        if (document != null)
        {
            _documents.Remove(document);
        }
    }

    public Document? GetById(Guid id)
    {
        return _documents.FirstOrDefault(d => d.Id == id);
    }

    public List<Document> GetAll()
    {
        return _documents;
    }
}