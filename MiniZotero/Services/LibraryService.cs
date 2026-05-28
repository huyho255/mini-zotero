using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public sealed class LibraryService
    {
        private readonly DocumentRepository _documentRepository;
        private readonly NoteService _noteService;

        public LibraryService(
            DocumentRepository documentRepository,
            NoteService noteService)
        {
            _documentRepository = documentRepository;
            _noteService = noteService;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            return _documentRepository.LoadDocuments();
        }

        public OperationResult<ImportDocumentResult> ImportDocument(
            string filePath,
            IList<DocumentItem> documents)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return OperationResult<ImportDocumentResult>.Failure("Choose a PDF file to import.");
            }

            try
            {
                var document = _documentRepository.ImportDocument(filePath, documents);
                var existingDocument = documents.FirstOrDefault(existingDocument =>
                    existingDocument.Id == document.Id);
                var status = ImportDocumentStatus.Imported;

                if (existingDocument is null)
                {
                    documents.Add(document);
                }
                else if (existingDocument.IsDeleted)
                {
                    existingDocument.IsDeleted = false;
                    existingDocument.DeletedAt = null;
                    status = ImportDocumentStatus.RestoredFromTrash;
                }
                else
                {
                    status = ImportDocumentStatus.SkippedDuplicate;
                }

                SaveDocuments(documents);

                return OperationResult<ImportDocumentResult>.Success(
                    new ImportDocumentResult(document, status),
                    GetImportMessage(status, document.Title));
            }
            catch (FileNotFoundException)
            {
                return OperationResult<ImportDocumentResult>.Failure("The selected PDF file no longer exists.");
            }
            catch (IOException)
            {
                return OperationResult<ImportDocumentResult>.Failure("Could not import the PDF file.");
            }
            catch (UnauthorizedAccessException)
            {
                return OperationResult<ImportDocumentResult>.Failure("MiniZotero does not have permission to import this PDF.");
            }
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            _documentRepository.SaveDocuments(documents);
        }

        public void MarkDocumentOpened(DocumentItem document, IEnumerable<DocumentItem> documents)
        {
            document.LastOpenedAt = DateTimeOffset.Now;
            SaveDocuments(documents);
        }

        public void ToggleStar(DocumentItem document, IEnumerable<DocumentItem> documents)
        {
            if (document.IsDeleted)
            {
                return;
            }

            document.IsStarred = !document.IsStarred;
            SaveDocuments(documents);
        }

        public void MoveToTrash(DocumentItem document, IEnumerable<DocumentItem> documents)
        {
            if (document.IsDeleted)
            {
                return;
            }

            document.IsDeleted = true;
            document.DeletedAt = DateTimeOffset.Now;
            SaveDocuments(documents);
        }

        public void Restore(DocumentItem document, IEnumerable<DocumentItem> documents)
        {
            if (!document.IsDeleted)
            {
                return;
            }

            document.IsDeleted = false;
            document.DeletedAt = null;
            SaveDocuments(documents);
        }

        public void DeleteForever(DocumentItem document, IList<DocumentItem> documents)
        {
            if (!document.IsDeleted)
            {
                return;
            }

            _documentRepository.DeleteStoredPdfFile(document);
            documents.Remove(document);
            SaveDocuments(documents);
        }

        public IEnumerable<DocumentItem> GetNavigationDocuments(
            IEnumerable<DocumentItem> documents,
            string? navigationName)
        {
            return navigationName switch
            {
                "Recent" => documents
                    .Where(document => !document.IsDeleted && document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "Starred" => documents
                    .Where(document => !document.IsDeleted && document.IsStarred)
                    .OrderBy(document => document.Title),

                "Trash" => documents
                    .Where(document => document.IsDeleted)
                    .OrderByDescending(document => document.DeletedAt),

                _ => documents
                    .Where(document => !document.IsDeleted)
                    .OrderBy(document => document.Title)
            };
        }

        public IEnumerable<DocumentItem> ApplySmartCollectionFilter(
            IEnumerable<DocumentItem> documents,
            string? smartCollectionKind)
        {
            return smartCollectionKind switch
            {
                "reading" => documents.Where(document => document.LastReadPage > 1),

                "new" => documents.Where(document =>
                    document.AddedAt >= DateTimeOffset.Now.AddDays(-7)),

                "recent" => documents
                    .Where(document => document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "unread" => documents.Where(document => document.LastOpenedAt is null),

                _ => documents
            };
        }

        public bool MatchesSearch(DocumentItem document, string keyword)
        {
            return Contains(document.Title, keyword) ||
                   Contains(document.FilePath, keyword) ||
                   Contains(document.OriginalFilePath, keyword) ||
                   document.Tags.Any(tag => Contains(tag, keyword)) ||
                   Contains(_noteService.LoadNote(document.Id), keyword);
        }

        private static bool Contains(string? value, string keyword)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }

        private static string GetImportMessage(
            ImportDocumentStatus status,
            string title)
        {
            return status switch
            {
                ImportDocumentStatus.Imported => $"Imported {title}.",
                ImportDocumentStatus.RestoredFromTrash => $"Restored {title}.",
                ImportDocumentStatus.SkippedDuplicate => $"{title} is already in the library.",
                _ => "Import finished."
            };
        }
    }
}
