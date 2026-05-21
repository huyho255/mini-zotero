using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class DocumentRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;

        public DocumentRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            var libraryPath = _storageService.LibraryFilePath;
            if (!File.Exists(libraryPath))
            {
                return [];
            }

            try
            {
                var json = File.ReadAllText(libraryPath);
                return JsonSerializer.Deserialize<List<DocumentItem>>(json, JsonOptions) ?? [];
            }
            catch (IOException)
            {
                return [];
            }
            catch (JsonException)
            {
                return [];
            }
        }

        public DocumentItem AddDocument(string filePath)
        {
            var documents = LoadDocuments().ToList();
            var existingDocument = documents.FirstOrDefault(document =>
                string.Equals(document.FilePath, filePath, StringComparison.OrdinalIgnoreCase));

            if (existingDocument is not null)
            {
                return existingDocument;
            }

            var document = new DocumentItem(
                Guid.NewGuid().ToString("N"),
                Path.GetFileName(filePath),
                filePath,
                DateTimeOffset.Now);

            documents.Add(document);
            SaveDocuments(documents);

            return document;
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            var json = JsonSerializer.Serialize(documents, JsonOptions);
            File.WriteAllText(_storageService.LibraryFilePath, json);
        }
    }
}
