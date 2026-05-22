using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class HighlightRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;

        public HighlightRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public IReadOnlyList<HighlightItem> LoadHighlights(string documentId)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return [];
            }

            var path = GetHighlightFilePath(documentId);

            if (!File.Exists(path))
            {
                return [];
            }

            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<List<HighlightItem>>(json, JsonOptions) ?? [];
            }
            catch (IOException)
            {
                return [];
            }
            catch (JsonException)
            {
                return [];
            }
            catch (UnauthorizedAccessException)
            {
                return [];
            }
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
            var json = JsonSerializer.Serialize(highlights, JsonOptions);

            File.WriteAllText(path, json);
        }

        private string GetHighlightFilePath(string documentId)
        {
            return Path.Combine(_storageService.HighlightsFolderPath, $"{documentId}.json");
        }
    }
}
