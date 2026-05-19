using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface IDocumentService
{
    Document ImportDocument(string filePath);

    List<Document> GetAllDocuments();

    Document? GetDocumentById(Guid id);

    void DeleteDocument(Guid id);

    void AddTag(Guid documentId, string tagName);

    void AddNote(Guid documentId, string markdownContent);
}