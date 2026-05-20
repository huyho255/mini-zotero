using System;

namespace MiniZotero.Models;

public class DocumentItem
{
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public DateTime ImportedAt { get; set; } = DateTime.Now;

    public DateTime? LastOpenedAt { get; set; }

    public int LastReadPage { get; set; } = 0;

    public int TotalPages { get; set; } = 0;

    public bool IsStarred { get; set; } = false;
}