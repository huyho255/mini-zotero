using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class HighlightRepository
    {
        private readonly AppStorageService _storageService;
        private readonly JsonFileStore _jsonFileStore;

        public HighlightRepository(AppStorageService storageService)
            : this(storageService, new JsonFileStore())
        {
        }

        public HighlightRepository(
            AppStorageService storageService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _jsonFileStore = jsonFileStore;
        }

        public IReadOnlyList<HighlightItem> LoadHighlights(string documentId)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return [];
            }

            return _jsonFileStore.Load(GetHighlightFilePath(documentId), new List<HighlightItem>());
        }

        public HighlightItem AddHighlight(HighlightItem highlight)
        {
            if (string.IsNullOrWhiteSpace(highlight.DocumentId))
            {
                throw new InvalidOperationException("Highlight must have a document id.");
            }

            if (string.IsNullOrWhiteSpace(highlight.Id))
            {
                highlight.Id = Guid.NewGuid().ToString("N");
            }

            if (highlight.CreatedAt == default)
            {
                highlight.CreatedAt = DateTimeOffset.Now;
            }

            var highlights = LoadHighlights(highlight.DocumentId).ToList();
            highlights.Add(highlight);

            SaveHighlights(highlight.DocumentId, highlights);

            return highlight;
        }

        public void DeleteHighlight(string documentId, string highlightId)
        {
            if (string.IsNullOrWhiteSpace(documentId) ||
                string.IsNullOrWhiteSpace(highlightId))
            {
                return;
            }

            var highlights = LoadHighlights(documentId).ToList();
            highlights.RemoveAll(highlight => highlight.Id == highlightId);

            SaveHighlights(documentId, highlights);
        }

        public void SaveHighlights(string documentId, IEnumerable<HighlightItem> highlights)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return;
            }

            var path = GetHighlightFilePath(documentId);
            _jsonFileStore.Save(path, highlights);
        }

        private string GetHighlightFilePath(string documentId)
        {
            return Path.Combine(_storageService.HighlightsFolderPath, $"{documentId}.json");
        }
    }
}
