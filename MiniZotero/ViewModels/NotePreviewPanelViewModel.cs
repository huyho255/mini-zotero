namespace MiniZotero.ViewModels;

public class NotePreviewPanelViewModel
{
    public bool HasActiveDocument { get; set; } = false;

    public string NotePlaceholder { get; } = "Open a document to start taking notes...";

    public string PreviewTitle { get; } = "Preview highlights";
    public string PreviewDescription { get; } = "Highlights from the current PDF will appear here.";
    public string EmptyHighlightTitle { get; } = "No highlights yet";
    public string EmptyHighlightMessage { get; } = "Select text in a PDF to create highlights";
}