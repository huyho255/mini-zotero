namespace MiniZotero.Services
{
    public sealed class PdfService : IPdfService
    {
        private static readonly PdfJsServerService PdfServer = new();

        public void EnsureServerStarted()
        {
            PdfServer.Start();
        }

        public string CreateViewerUri(
            string documentKey,
            string pdfFilePath,
            int pageNumber = 1,
            int zoomPercent = 120,
            string? reloadToken = null)
        {
            EnsureServerStarted();

            return PdfServer.RegisterPdf(
                documentKey,
                pdfFilePath,
                pageNumber,
                zoomPercent,
                reloadToken);
        }
    }
}