namespace MiniZotero.Core.Models;

public class Author
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string FullName { get; set; } = string.Empty;
}