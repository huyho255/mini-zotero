using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public sealed class LibraryService : ILibraryService
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentImportService _documentImportService;
        private readonly INoteService _noteService;

        public LibraryService(
            IDocumentRepository documentRepository,
            INoteService noteService)
            : this(documentRepository, noteService, new DocumentImportService(documentRepository))
        {
        }

        public LibraryService(
            IDocumentRepository documentRepository,
            INoteService noteService,
            IDocumentImportService documentImportService)
        {
            _documentRepository = documentRepository;
            _noteService = noteService;
            _documentImportService = documentImportService;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            return _documentRepository.LoadDocuments();
        }

        public OperationResult<ImportDocumentResult> ImportDocument(
            string filePath,
            IList<DocumentItem> documents)
        {
            return _documentImportService.ImportDocument(filePath, documents);
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

        public async Task EmptyTrashAsync(IList<DocumentItem> documents)
        {
            var trashItems = documents.Where(d => d.IsDeleted).ToList();
            
            if (trashItems.Count == 0)
            {
                return;
            }

            await Task.Run(() =>
            {
                foreach (var document in trashItems)
                {
                    _documentRepository.DeleteStoredPdfFile(document);
                }
            });

            foreach (var document in trashItems)
            {
                documents.Remove(document);
            }

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
                   document.Authors.Any(author => Contains(author, keyword)) ||
                   Contains(document.Year?.ToString(), keyword) ||
                   Contains(document.Doi, keyword) ||
                   Contains(document.JournalOrPublisher, keyword) ||
                   Contains(document.Abstract, keyword) ||
                   Contains(document.DocumentType, keyword) ||
                   Contains(_noteService.LoadNote(document.Id), keyword);
        }

        private static bool Contains(string? value, string keyword)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }
    }
}
