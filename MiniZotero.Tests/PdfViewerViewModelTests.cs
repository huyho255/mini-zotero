using System.Collections.Generic;
using MiniZotero.ViewModels;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class PdfViewerViewModelTests
    {
        [Fact]
        public void DefaultsExposeReadablePageAndZoomText()
        {
            var viewModel = new PdfViewerViewModel();

            Assert.Equal(0, viewModel.TotalPages);
            Assert.Equal("1 / --", viewModel.PageDisplayText);
            Assert.Equal("120%", viewModel.ZoomDisplayText);
            Assert.Equal("0 / 0", viewModel.SearchResultText);
        }

        [Fact]
        public void UpdatingViewerStateRefreshesPageAndZoomText()
        {
            var viewModel = new PdfViewerViewModel();

            viewModel.UpdateReadingStateFromViewer(3, 158, 12);

            Assert.Equal(3, viewModel.CurrentPage);
            Assert.Equal(12, viewModel.TotalPages);
            Assert.Equal("3 / 12", viewModel.PageDisplayText);
            Assert.Equal("158%", viewModel.ZoomDisplayText);
        }

        [Fact]
        public void UpdatingSearchStateRefreshesSearchResultText()
        {
            var viewModel = new PdfViewerViewModel();

            viewModel.UpdateSearchState(12, 2);

            Assert.Equal(12, viewModel.SearchResultCount);
            Assert.Equal(2, viewModel.CurrentSearchResultIndex);
            Assert.Equal("3 / 12", viewModel.SearchResultText);

            viewModel.UpdateSearchState(0, -1);

            Assert.Equal("0 / 0", viewModel.SearchResultText);
        }

        [Fact]
        public void ProcessViewerMessageUpdatesReadingAndSearchState()
        {
            var viewModel = new PdfViewerViewModel();

            viewModel.ProcessViewerMessage("""
                {
                    "type": "searchChanged",
                    "pageNumber": 4,
                    "zoomPercent": 175,
                    "totalPages": 20,
                    "searchResultCount": 3,
                    "currentSearchResultIndex": 1
                }
                """);

            Assert.Equal(4, viewModel.CurrentPage);
            Assert.Equal(175, viewModel.ZoomPercent);
            Assert.Equal(20, viewModel.TotalPages);
            Assert.Equal("2 / 3", viewModel.SearchResultText);
        }

        [Fact]
        public void ProcessViewerMessageRaisesHighlightCreated()
        {
            var viewModel = new PdfViewerViewModel();
            string? highlightedText = null;
            int highlightedPage = 0;

            viewModel.HighlightCreated += (text, pageNumber, _) =>
            {
                highlightedText = text;
                highlightedPage = pageNumber;
            };

            viewModel.ProcessViewerMessage("""
                {
                    "type": "highlightCreated",
                    "pageNumber": 2,
                    "zoomPercent": 120,
                    "text": "selected text",
                    "rects": []
                }
                """);

            Assert.Equal("selected text", highlightedText);
            Assert.Equal(2, highlightedPage);
        }

        [Fact]
        public void PdfCommandsEmitExpectedScripts()
        {
            var viewModel = new PdfViewerViewModel();
            var scripts = new List<string>();
            viewModel.ScriptRequested += scripts.Add;

            viewModel.UpdateReadingStateFromViewer(2, 120, 4);
            viewModel.GoToPreviousPageCommand.Execute(null);
            viewModel.GoToNextPageCommand.Execute(null);
            viewModel.ZoomInCommand.Execute(null);
            viewModel.ZoomOutCommand.Execute(null);
            viewModel.FitWidthCommand.Execute(null);
            viewModel.FitPageCommand.Execute(null);
            viewModel.PdfSearchText = "heart rate";
            viewModel.SearchInPdfCommand.Execute(null);
            viewModel.GoToNextSearchResultCommand.Execute(null);
            viewModel.GoToPreviousSearchResultCommand.Execute(null);
            viewModel.ClearPdfSearchCommand.Execute(null);
            viewModel.ActivateHandToolCommand.Execute(null);
            viewModel.ActivateSelectToolCommand.Execute(null);
            viewModel.ActivateHighlightToolCommand.Execute(null);

            Assert.Contains("window.miniZoteroPdf?.goToPage?.(1);", scripts);
            Assert.Contains("window.miniZoteroPdf?.goToPage?.(3);", scripts);
            Assert.Contains("window.miniZoteroPdf?.zoomIn?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.zoomOut?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.fitWidth?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.fitPage?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.searchText?.(\"heart rate\");", scripts);
            Assert.Contains("window.miniZoteroPdf?.goToNextSearchResult?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.goToPreviousSearchResult?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.clearSearch?.();", scripts);
            Assert.Contains("window.miniZoteroPdf?.setToolMode?.(\"hand\");", scripts);
            Assert.Contains("window.miniZoteroPdf?.setToolMode?.(\"select\");", scripts);
            Assert.Contains("window.miniZoteroPdf?.setToolMode?.(\"highlight\");", scripts);
        }
    }
}
