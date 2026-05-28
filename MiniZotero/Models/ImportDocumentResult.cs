namespace MiniZotero.Models
{
    public sealed class ImportDocumentResult
    {
        public ImportDocumentResult(
            DocumentItem document,
            ImportDocumentStatus status)
        {
            Document = document;
            Status = status;
        }

        public DocumentItem Document { get; }

        public ImportDocumentStatus Status { get; }
    }

    public enum ImportDocumentStatus
    {
        Imported,
        SkippedDuplicate,
        RestoredFromTrash
    }
}
