namespace MiniZotero.Core.Models;

public class Collection
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;

    public List<Document> Documents { get; set; } = new();
}