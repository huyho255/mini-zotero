using System.Collections.ObjectModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels;

public class SidebarViewModel
{
    public string SearchText { get; set; } = string.Empty;

    public ObservableCollection<DocumentItem> Documents { get; } = new();

    public bool HasDocuments => Documents.Count > 0;

    public string EmptyTitle { get; } = "No documents yet";

    public string EmptyMessage { get; } = "Import a PDF to start";
}