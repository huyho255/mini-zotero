using System.Collections.ObjectModel;

namespace MiniZotero.ViewModels;

public class SidebarViewModel
{
    public string SearchText { get; set; } = string.Empty;

    public ObservableCollection<string> LibraryMenus { get; } = new()
    {
        "All Documents",
        "Recent",
        "Starred",
        "Trash"
    };

    public bool HasDocuments { get; set; } = false;

    public string EmptyTitle { get; } = "No documents yet";
    public string EmptyMessage { get; } = "Import a PDF to start";
}