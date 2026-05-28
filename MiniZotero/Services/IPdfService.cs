namespace MiniZotero.Services
{
    public interface IPdfService
    {
        void EnsureServerStarted();

        string CreateViewerUri(
            string documentKey,
            string pdfFilePath,
            int pageNumber = 1,
            int zoomPercent = 120,
            string? reloadToken = null);
    }
}