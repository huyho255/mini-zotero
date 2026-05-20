using MiniZotero.Models;

namespace MiniZotero.ViewModels;

public class MainWindowViewModel
{
    public string AppTitle { get; } = "MiniZotero";

    public SidebarViewModel Sidebar { get; } = new();

    public TabWorkspaceViewModel Workspace { get; } = new();

    public NotePreviewPanelViewModel NotePanel { get; } = new();

    public MainWindowViewModel()
    {
        Sidebar.DocumentSelected += OnDocumentSelected;
    }

    private void OnDocumentSelected(DocumentItem document)
    {
        Workspace.OpenDocument(document);
        NotePanel.SetActiveDocument(document);
    }
}
