using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public interface IDocumentImportService
    {
        OperationResult<ImportDocumentResult> ImportDocument(string filePath, IList<DocumentItem> documents);
    }
}