namespace MiniZotero.Core.Models;

public class SmartCollection : Collection
{
    public string SearchKeyword { get; set; } = string.Empty;

    public string RequiredTag { get; set; } = string.Empty;
}