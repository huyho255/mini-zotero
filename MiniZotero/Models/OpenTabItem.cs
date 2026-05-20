namespace MiniZotero.Models;

public class OpenTabItem
{
    public string Id { get; set; } = string.Empty;

    public string DocumentId { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public int CurrentPage { get; set; } = 0;

    public int ZoomPercent { get; set; } = 100;

    public bool IsActive { get; set; } = false;
}