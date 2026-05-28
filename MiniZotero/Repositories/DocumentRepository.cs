using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class DocumentRepository : IDocumentRepository
    {
        private readonly AppStorageService _storageService;
        private readonly AutoTagService _autoTagService;
        private readonly JsonFileStore _jsonFileStore;

        public DocumentRepository(AppStorageService storageService)
            : this(storageService, new AutoTagService())
        {
        }

        public DocumentRepository(
            AppStorageService storageService,
            AutoTagService autoTagService)
            : this(storageService, autoTagService, new JsonFileStore())
        {
        }

        public DocumentRepository(
            AppStorageService storageService,
            AutoTagService autoTagService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _autoTagService = autoTagService;
            _jsonFileStore = jsonFileStore;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            var documents = _jsonFileStore
                .Load(_storageService.LibraryFilePath, new List<DocumentItem>());
            var changed = NormalizeDocuments(documents);
            changed |= MigrateDocumentsToStorage(documents);
            changed |= ApplyMissingAutoTags(documents);

            if (changed)
            {
                SaveDocuments(documents);
            }

            return documents;
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
                ApplyAutoTags(existingDocument, normalizedSourcePath);
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

            ApplyAutoTags(document, normalizedSourcePath);

            return document;
        }

        public DocumentItem AddDocument(string filePath)
        {
            var documents = LoadDocuments().ToList();
            var document = ImportDocument(filePath, documents);

            if (!documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                documents.Add(document);
            }

            SaveDocuments(documents);

            return document;
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            _jsonFileStore.Save(_storageService.LibraryFilePath, documents);
        }

        public void DeleteStoredPdfFile(DocumentItem document)
        {
            if (string.IsNullOrWhiteSpace(document.FilePath))
            {
                return;
            }

            try
            {
                if (File.Exists(document.FilePath) && IsStoredPdfPath(document.FilePath))
                {
                    File.Delete(document.FilePath);
                }
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
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

        private bool ApplyMissingAutoTags(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                var sourcePath = !string.IsNullOrWhiteSpace(document.OriginalFilePath)
                    ? document.OriginalFilePath
                    : document.FilePath;

                if (string.IsNullOrWhiteSpace(sourcePath))
                {
                    continue;
                }

                changed |= ApplyAutoTags(document, sourcePath);
            }

            return changed;
        }

        private bool ApplyAutoTags(DocumentItem document, string sourceFilePath)
        {
            document.Tags ??= [];
            var changed = false;

            foreach (var tag in _autoTagService.GenerateTags(sourceFilePath, document.Title))
            {
                var exists = document.Tags.Any(existingTag =>
                    string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    continue;
                }

                document.Tags.Add(tag);
                changed = true;
            }

            return changed;
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

                if (document.LastZoomPercent < 50 || document.LastZoomPercent > 400)
                {
                    document.LastZoomPercent = 120;
                    changed = true;
                }

                if (document.Tags is null)
                {
                    document.Tags = [];
                    changed = true;
                }

                if (document.Authors is null)
                {
                    document.Authors = [];
                    changed = true;
                }

                if (!document.IsDeleted && document.DeletedAt is not null)
                {
                    document.DeletedAt = null;
                    changed = true;
                }

                if (document.IsDeleted && document.DeletedAt is null)
                {
                    document.DeletedAt = DateTimeOffset.Now;
                    changed = true;
                }
            }

            return changed;
        }
    }
}
