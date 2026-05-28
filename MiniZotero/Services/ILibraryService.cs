using System.Collections.Generic;
using System.Threading.Tasks;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public interface ILibraryService
    {
        IReadOnlyList<DocumentItem> LoadDocuments();

        OperationResult<ImportDocumentResult> ImportDocument(string filePath, IList<DocumentItem> documents);

        void SaveDocuments(IEnumerable<DocumentItem> documents);

        void MarkDocumentOpened(DocumentItem document, IEnumerable<DocumentItem> documents);

        void ToggleStar(DocumentItem document, IEnumerable<DocumentItem> documents);

        void MoveToTrash(DocumentItem document, IEnumerable<DocumentItem> documents);

        void Restore(DocumentItem document, IEnumerable<DocumentItem> documents);

        void DeleteForever(DocumentItem document, IList<DocumentItem> documents);

        Task EmptyTrashAsync(IList<DocumentItem> documents);

        IEnumerable<DocumentItem> GetNavigationDocuments(IEnumerable<DocumentItem> documents, string? navigationName);

        IEnumerable<DocumentItem> ApplySmartCollectionFilter(IEnumerable<DocumentItem> documents, string? smartCollectionKind);

        bool MatchesSearch(DocumentItem document, string keyword);
    }
}