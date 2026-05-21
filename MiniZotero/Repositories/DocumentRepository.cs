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
                var documents = JsonSerializer.Deserialize<List<DocumentItem>>(json, JsonOptions) ?? [];
                var changed = NormalizeDocuments(documents);
                changed |= MigrateDocumentsToStorage(documents);

                if (changed)
                {
                    SaveDocuments(documents);
                }

                return documents;
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

        public DocumentItem ImportDocument(string sourceFilePath, IEnumerable<DocumentItem> existingDocuments)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("The selected PDF file does not exist.", sourceFilePath);
            }

            var normalizedSourcePath = Path.GetFullPath(sourceFilePath);
            var existingDocument = existingDocuments.FirstOrDefault(document =>
                IsSamePath(document.OriginalFilePath, normalizedSourcePath) ||
                IsSamePath(document.FilePath, normalizedSourcePath));

            if (existingDocument is not null)
            {
                return existingDocument;
            }

            var documentId = Guid.NewGuid().ToString("N");
            var destinationPath = Path.Combine(_storageService.PdfFolderPath, $"{documentId}.pdf");
            File.Copy(normalizedSourcePath, destinationPath, overwrite: false);

            var document = new DocumentItem(
                documentId,
                Path.GetFileNameWithoutExtension(normalizedSourcePath),
                destinationPath,
                normalizedSourcePath,
                DateTimeOffset.Now,
                lastOpenedAt: null,
                lastReadPage: 1);

            return document;
        }

        public DocumentItem AddDocument(string filePath)
        {
            var documents = LoadDocuments().ToList();
            var document = ImportDocument(filePath, documents);

            if (!documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                documents.Add(document);
                SaveDocuments(documents);
            }

            return document;
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            var json = JsonSerializer.Serialize(documents, JsonOptions);
            File.WriteAllText(_storageService.LibraryFilePath, json);
        }

        private static bool IsSamePath(string? left, string right)
        {
            if (string.IsNullOrWhiteSpace(left))
            {
                return false;
            }

            return string.Equals(Path.GetFullPath(left), right, StringComparison.OrdinalIgnoreCase);
        }

        private bool MigrateDocumentsToStorage(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                if (string.IsNullOrWhiteSpace(document.FilePath) ||
                    IsStoredPdfPath(document.FilePath) ||
                    !File.Exists(document.FilePath))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(document.OriginalFilePath))
                {
                    document.OriginalFilePath = document.FilePath;
                }

                var destinationPath = Path.Combine(_storageService.PdfFolderPath, $"{document.Id}.pdf");
                if (!File.Exists(destinationPath))
                {
                    File.Copy(document.FilePath, destinationPath, overwrite: false);
                }

                document.FilePath = destinationPath;
                changed = true;
            }

            return changed;
        }

        private bool IsStoredPdfPath(string filePath)
        {
            var normalizedFilePath = Path.GetFullPath(filePath);
            var normalizedPdfFolderPath = Path.GetFullPath(_storageService.PdfFolderPath);

            return normalizedFilePath.StartsWith(
                normalizedPdfFolderPath,
                StringComparison.OrdinalIgnoreCase);
        }

        private static bool NormalizeDocuments(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                if (string.IsNullOrWhiteSpace(document.Id))
                {
                    document.Id = Guid.NewGuid().ToString("N");
                    changed = true;
                }

                if (string.IsNullOrWhiteSpace(document.OriginalFilePath))
                {
                    document.OriginalFilePath = document.FilePath;
                    changed = true;
                }

                if (string.IsNullOrWhiteSpace(document.Title) &&
                    !string.IsNullOrWhiteSpace(document.FilePath))
                {
                    document.Title = Path.GetFileNameWithoutExtension(document.FilePath);
                    changed = true;
                }

                if (document.LastReadPage < 1)
                {
                    document.LastReadPage = 1;
                    changed = true;
                }
            }

            return changed;
        }
    }
}
