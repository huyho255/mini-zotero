namespace MiniZotero.ViewModels;

public class PdfViewerViewModel
{
    public bool HasDocumentLoaded { get; set; } = false;

    public int CurrentPage { get; set; } = 0;
    public int TotalPages { get; set; } = 0;
    public int ZoomPercent { get; set; } = 100;

    public string EmptyTitle { get; } = "Select a document to view";
    public string EmptyMessage { get; } = "or import a new PDF file";
    public string StatusText { get; } = "Ready";
    public string DocumentStatus { get; } = "No document loaded";
}