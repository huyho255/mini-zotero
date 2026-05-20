namespace MiniZotero.ViewModels;

public class MainWindowViewModel
{
    public string AppTitle { get; } = "MiniZotero";

    public SidebarViewModel Sidebar { get; } = new();
    public TabWorkspaceViewModel Workspace { get; } = new();
    public PdfViewerViewModel PdfViewer { get; } = new();
    public NotePreviewPanelViewModel NotePanel { get; } = new();
}