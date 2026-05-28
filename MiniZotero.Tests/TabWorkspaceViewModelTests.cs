using MiniZotero.Models;
using MiniZotero.ViewModels;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class TabWorkspaceViewModelTests
    {
        [Fact]
        public void OpenDocumentCreatesOneTab()
        {
            var viewModel = new TabWorkspaceViewModel();
            var document = CreateDocument("doc-1");

            viewModel.OpenDocument(document);

            Assert.Single(viewModel.OpenTabs);
            Assert.Equal(document, viewModel.ActiveDocument);
            Assert.NotNull(viewModel.ActivePdfViewer);
        }

        [Fact]
        public void OpenSameDocumentActivatesExistingTab()
        {
            var viewModel = new TabWorkspaceViewModel();
            var document = CreateDocument("doc-1");

            viewModel.OpenDocument(document);
            viewModel.OpenDocument(document);

            Assert.Single(viewModel.OpenTabs);
        }

        [Fact]
        public void OpenSecondDocumentCreatesSecondTab()
        {
            var viewModel = new TabWorkspaceViewModel();

            viewModel.OpenDocument(CreateDocument("doc-1"));
            viewModel.OpenDocument(CreateDocument("doc-2"));

            Assert.Equal(2, viewModel.OpenTabs.Count);
            Assert.Equal("doc-2", viewModel.ActiveDocument?.Id);
        }

        [Fact]
        public void CloseActiveTabSelectsAnotherTab()
        {
            var viewModel = new TabWorkspaceViewModel();

            viewModel.OpenDocument(CreateDocument("doc-1"));
            viewModel.OpenDocument(CreateDocument("doc-2"));

            viewModel.CloseActiveDocumentCommand.Execute(null);

            Assert.Single(viewModel.OpenTabs);
            Assert.Equal("doc-1", viewModel.ActiveDocument?.Id);
        }

        [Fact]
        public void CloseLastTabClearsActiveTab()
        {
            var viewModel = new TabWorkspaceViewModel();

            viewModel.OpenDocument(CreateDocument("doc-1"));
            viewModel.CloseActiveDocumentCommand.Execute(null);

            Assert.Empty(viewModel.OpenTabs);
            Assert.Null(viewModel.ActiveTab);
            Assert.Null(viewModel.ActiveDocument);
        }

        [Fact]
        public void EachTabOwnsSeparatePdfViewer()
        {
            var viewModel = new TabWorkspaceViewModel();

            viewModel.OpenDocument(CreateDocument("doc-1"));
            viewModel.OpenDocument(CreateDocument("doc-2"));

            Assert.NotSame(viewModel.OpenTabs[0].PdfViewer, viewModel.OpenTabs[1].PdfViewer);
        }

        private static DocumentItem CreateDocument(string id)
        {
            return new DocumentItem
            {
                Id = id,
                Title = id,
                FilePath = "missing.pdf"
            };
        }
    }
}
