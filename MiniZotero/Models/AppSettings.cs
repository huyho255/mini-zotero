namespace MiniZotero.Models
{
    public sealed class AppSettings
    {
        public string? WatchFolderPath { get; set; }

        public string ThemeMode { get; set; } = "System";

        public int DefaultPdfZoomPercent { get; set; } = 120;

        public bool RestorePreviousSession { get; set; }

        public System.Collections.Generic.List<string> OpenDocumentIds { get; set; } = new();

        public string? ActiveDocumentId { get; set; }

        public string? StorageRootPath { get; set; }
    }
}
