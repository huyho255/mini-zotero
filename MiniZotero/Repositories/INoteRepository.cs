namespace MiniZotero.Repositories
{
    public interface INoteRepository
    {
        string LoadNote(string documentId);

        void SaveNote(string documentId, string text);
    }
}