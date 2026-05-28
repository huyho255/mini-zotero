using System.IO;
using System.Linq;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class NoteRepository : INoteRepository
    {
        private readonly AppStorageService _storageService;

        public NoteRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public string LoadNote(string documentId)
        {
            var notePath = GetNotePath(documentId);

            return File.Exists(notePath)
                ? File.ReadAllText(notePath)
                : string.Empty;
        }

        public void SaveNote(string documentId, string text)
        {
            var notePath = GetNotePath(documentId);
            File.WriteAllText(notePath, text);
        }

        private string GetNotePath(string documentId)
        {
            var safeDocumentId = string.Concat(
                documentId.Select(character =>
                    Path.GetInvalidFileNameChars().Contains(character) ? '_' : character));

            if (string.IsNullOrWhiteSpace(safeDocumentId))
            {
                safeDocumentId = "untitled";
            }

            return Path.Combine(_storageService.NotesFolderPath, $"{safeDocumentId}.md");
        }
    }
}
