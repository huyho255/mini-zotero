using System;
using System.IO;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class PdfViewerViewModel : ViewModelBase
    {
        private static readonly PdfJsServerService PdfServer = new();

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private bool _hasDocumentLoaded;

        [ObservableProperty]
        private string _documentPath = string.Empty;

        [ObservableProperty]
        private Uri? _viewerSource;

        [ObservableProperty]
        private int _currentPage = 1;

        [ObservableProperty]
        private int _zoomPercent = 120;

        [ObservableProperty]
        private string _statusText = "Ready";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsHandToolActive))]
        [NotifyPropertyChangedFor(nameof(IsSelectToolActive))]
        private string _toolMode = "select";

        [ObservableProperty]
        private string _emptyTitle = "Select a document to view";

        [ObservableProperty]
        private string _emptyMessage = "Import a PDF file from the sidebar.";

        public bool IsEmptyViewVisible => !HasDocumentLoaded;

        public bool IsHandToolActive => ToolMode == "hand";

        public bool IsSelectToolActive => ToolMode == "select";

        public void LoadDocument(DocumentItem document)
        {
            if (!File.Exists(document.FilePath))
            {
                DocumentPath = document.FilePath;
                StatusText = "File not found";
                EmptyTitle = document.Title;
                EmptyMessage = "The selected PDF file does not exist.";
                HasDocumentLoaded = false;
                return;
            }

            DocumentPath = document.FilePath;
            CurrentPage = 1;
            ZoomPercent = 120;

            PdfServer.Start();

            string documentKey = Convert.ToBase64String(Encoding.UTF8.GetBytes(document.FilePath))
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');

            string viewerUrl = PdfServer.RegisterPdf(
                documentKey,
                document.FilePath,
                CurrentPage
            );

            ViewerSource = new Uri(viewerUrl);

            StatusText = "Document loaded";
            EmptyTitle = document.Title;
            EmptyMessage = string.Empty;
            HasDocumentLoaded = true;
        }

        public void UpdateReadingStateFromViewer(int pageNumber, int zoomPercent)
        {
            if (pageNumber > 0)
            {
                CurrentPage = pageNumber;
            }

            if (zoomPercent > 0)
            {
                ZoomPercent = zoomPercent;
            }

            StatusText = $"Page {CurrentPage}";
        }

        public void SetHandTool()
        {
            ToolMode = "hand";
        }

        public void SetSelectTool()
        {
            ToolMode = "select";
        }
    }
}
