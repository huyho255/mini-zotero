using System;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public sealed class DocumentTabViewModel : ViewModelBase
    {
        public DocumentTabViewModel(
            DocumentItem document,
            Action<DocumentItem> persistReadingState,
            IPdfService pdfService)
        {
            Document = document;
            PdfViewer = new PdfViewerViewModel(persistReadingState, pdfService);
            PdfViewer.LoadDocument(document);
        }

        public DocumentItem Document { get; }

        public PdfViewerViewModel PdfViewer { get; }

        public string Title => Document.Title;
    }
}
