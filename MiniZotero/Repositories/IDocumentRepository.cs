using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Repositories
{
    public interface IDocumentRepository
    {
        IReadOnlyList<DocumentItem> LoadDocuments();

        void SaveDocuments(IEnumerable<DocumentItem> documents);

        DocumentItem ImportDocument(string sourceFilePath, IEnumerable<DocumentItem> existingDocuments);

        void DeleteStoredPdfFile(DocumentItem document);
    }
}