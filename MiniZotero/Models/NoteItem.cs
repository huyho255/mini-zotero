using System;

namespace MiniZotero.Models;

public class NoteItem
{
    public string Id { get; set; } = string.Empty;

    public string DocumentId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}