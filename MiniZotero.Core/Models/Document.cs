namespace MiniZotero.Core.Models;

public class Document
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public string FileType { get; set; } = string.Empty; // PDF / EPUB

    public DateTime ImportedAt { get; set; } = DateTime.Now;

    public List<Author> Authors { get; set; } = new();

    public List<Tag> Tags { get; set; } = new();

    public List<Note> Notes { get; set; } = new();
}