using System;
using System.Collections.Generic;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public sealed class HighlightService
    {
        private readonly HighlightRepository _highlightRepository;

        public HighlightService(HighlightRepository highlightRepository)
        {
            _highlightRepository = highlightRepository;
        }

        public IReadOnlyList<HighlightItem> LoadHighlights(string documentId)
        {
            return _highlightRepository.LoadHighlights(documentId);
        }

        public OperationResult<HighlightItem> AddHighlight(
            DocumentItem document,
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return OperationResult<HighlightItem>.Failure("Select text before creating a highlight.");
            }

            var highlight = new HighlightItem
            {
                DocumentId = document.Id,
                PageNumber = pageNumber < 1 ? 1 : pageNumber,
                Text = text.Trim(),
                Color = "yellow",
                Rects = rects.ToList()
            };

            try
            {
                _highlightRepository.AddHighlight(highlight);
                return OperationResult<HighlightItem>.Success(highlight, "Highlight saved.");
            }
            catch (Exception)
            {
                return OperationResult<HighlightItem>.Failure("Could not save the highlight.");
            }
        }

        public OperationResult DeleteHighlight(string documentId, string highlightId)
        {
            try
            {
                _highlightRepository.DeleteHighlight(documentId, highlightId);
                return OperationResult.Success("Highlight deleted.");
            }
            catch (Exception)
            {
                return OperationResult.Failure("Could not delete the highlight.");
            }
        }
    }
}
