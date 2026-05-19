using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface IDocumentRepository
{
    void Add(Document document);

    void Update(Document document);

    void Delete(Guid id);

    Document? GetById(Guid id);

    List<Document> GetAll();
}   