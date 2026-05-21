using System.IO;
using MiniZotero.Services;

namespace MiniZotero.Repositories;

public class NoteRepository
{
    private readonly AppStorageService _storage;

    public NoteRepository(AppStorageService storage)
    {
        _storage = storage;
    }

    public string LoadNote(string documentId)
    {
        string notePath = GetNotePath(documentId);

        if (!File.Exists(notePath))
        {
            return string.Empty;
        }

        return File.ReadAllText(notePath);
    }

    public void SaveNote(string documentId, string content)
    {
        string notePath = GetNotePath(documentId);

        File.WriteAllText(notePath, content);
    }

    private string GetNotePath(string documentId)
    {
        return Path.Combine(_storage.NotesFolderPath, $"{documentId}.md");
    }
}
