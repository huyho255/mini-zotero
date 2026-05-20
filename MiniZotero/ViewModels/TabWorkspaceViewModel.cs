namespace MiniZotero.ViewModels;

public class TabWorkspaceViewModel
{
    public bool HasOpenDocument { get; set; } = false;

    public string EmptyTabText { get; } = "No document opened";

    public string SearchHint { get; } = "Search";

    public PdfViewerViewModel PdfViewer { get; } = new();
}