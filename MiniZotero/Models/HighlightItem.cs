using System;

namespace MiniZotero.Models;

public class HighlightItem
{
    public string Id { get; set; } = string.Empty;

    public string DocumentId { get; set; } = string.Empty;

    public int PageNumber { get; set; }

    public string SelectedText { get; set; } = string.Empty;

    public string Color { get; set; } = "Yellow";

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}