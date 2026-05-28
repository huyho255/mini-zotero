using System.Collections.Generic;
using MiniZotero.Models;

namespace MiniZotero.Repositories
{
    public interface IHighlightRepository
    {
        IReadOnlyList<HighlightItem> LoadHighlights(string documentId);

        HighlightItem AddHighlight(HighlightItem highlight);

        void DeleteHighlight(string documentId, string highlightId);
    }
}