using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public interface INoteService
    {
        string LoadNote(string documentId);

        OperationResult SaveNote(string documentId, string text);

        OperationResult ExportDocumentNotes(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights,
            string outputPath);
    }
}