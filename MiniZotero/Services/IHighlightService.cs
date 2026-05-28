using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public interface IHighlightService
    {
        IReadOnlyList<HighlightItem> LoadHighlights(string documentId);

        OperationResult<HighlightItem> AddHighlight(
            DocumentItem document,
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects);

        OperationResult DeleteHighlight(string documentId, string highlightId);
    }
}