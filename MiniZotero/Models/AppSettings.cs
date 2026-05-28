namespace MiniZotero.Models
{
    public sealed class AppSettings
    {
        public string? WatchFolderPath { get; set; }

        public string ThemeMode { get; set; } = "System";

        public int DefaultPdfZoomPercent { get; set; } = 120;

        public bool AutoOpenLastDocument { get; set; }

        public string? StorageRootPath { get; set; }
    }
}
