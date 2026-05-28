using System;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class FeatureServiceTests
    {
        [Fact]
        public void LibraryServiceImportSkipsDuplicate()
        {
            using var directory = new TemporaryDirectory();
            var service = CreateLibraryService(directory, out _);
            var documents = new System.Collections.Generic.List<DocumentItem>();
            var pdfPath = Path.Combine(directory.Path, "doc.pdf");
            File.WriteAllBytes(pdfPath, [1, 2, 3]);

            var firstResult = service.ImportDocument(pdfPath, documents);
            var secondResult = service.ImportDocument(pdfPath, documents);

            Assert.True(firstResult.Succeeded);
            Assert.True(secondResult.Succeeded);
            Assert.Single(documents);
            Assert.Equal(ImportDocumentStatus.SkippedDuplicate, secondResult.Value?.Status);
        }

        [Fact]
        public void LibraryServiceTrashRestoreAndDeleteForeverUpdateLibrary()
        {
            using var directory = new TemporaryDirectory();
            var service = CreateLibraryService(directory, out _);
            var documents = new System.Collections.Generic.List<DocumentItem>();
            var pdfPath = Path.Combine(directory.Path, "doc.pdf");
            File.WriteAllBytes(pdfPath, [1, 2, 3]);
            var document = service.ImportDocument(pdfPath, documents).Value!.Document;

            service.MoveToTrash(document, documents);
            Assert.True(document.IsDeleted);

            service.Restore(document, documents);
            Assert.False(document.IsDeleted);

            service.MoveToTrash(document, documents);
            service.DeleteForever(document, documents);

            Assert.Empty(documents);
            Assert.False(File.Exists(document.FilePath));
        }

        [Fact]
        public void TagServiceAddsAndRemovesTagsIgnoringCase()
        {
            var service = new TagService();
            var document = new DocumentItem();

            Assert.True(service.AddTag(document, " CMOS "));
            Assert.False(service.AddTag(document, "cmos"));
            Assert.Single(document.Tags);

            Assert.True(service.RemoveTag(document, "cMoS"));
            Assert.Empty(document.Tags);
        }

        [Fact]
        public void LibraryServiceSearchMatchesNoteText()
        {
            using var directory = new TemporaryDirectory();
            var service = CreateLibraryService(directory, out var noteService);
            var document = new DocumentItem { Id = "doc", Title = "Title" };
            noteService.SaveNote(document.Id, "contains heartbeat sensor notes");

            Assert.True(service.MatchesSearch(document, "heartbeat"));
        }

        [Fact]
        public void NoteServiceExportReturnsFailureForBlankPath()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var service = new NoteService(
                new NoteRepository(storage),
                new MarkdownExportService());

            var result = service.ExportDocumentNotes(
                new DocumentItem { Title = "Doc" },
                "note",
                [],
                string.Empty);

            Assert.False(result.Succeeded);
        }

        [Fact]
        public void HighlightServiceAddsAndDeletesHighlights()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new HighlightRepository(storage);
            var service = new HighlightService(repository);
            var document = new DocumentItem { Id = "doc", Title = "Doc" };

            var addResult = service.AddHighlight(
                document,
                "selected text",
                2,
                [new HighlightRect { PageNumber = 2, Width = 10, Height = 4 }]);

            Assert.True(addResult.Succeeded);
            Assert.Single(service.LoadHighlights(document.Id));

            var deleteResult = service.DeleteHighlight(document.Id, addResult.Value!.Id);

            Assert.True(deleteResult.Succeeded);
            Assert.Empty(service.LoadHighlights(document.Id));
        }

        [Fact]
        public void LibraryServiceRecentAndUnreadUseLastOpenedAt()
        {
            using var directory = new TemporaryDirectory();
            var service = CreateLibraryService(directory, out _);
            var oldDocument = new DocumentItem
            {
                Title = "Old",
                LastOpenedAt = DateTimeOffset.Now.AddDays(-1)
            };
            var newDocument = new DocumentItem
            {
                Title = "New",
                LastOpenedAt = DateTimeOffset.Now
            };
            var unreadDocument = new DocumentItem
            {
                Title = "Unread",
                LastOpenedAt = null
            };
            var documents = new[] { oldDocument, unreadDocument, newDocument };

            var recent = service.GetNavigationDocuments(documents, "Recent").ToList();
            var unread = service.ApplySmartCollectionFilter(documents, "unread").ToList();

            Assert.Equal("New", recent[0].Title);
            Assert.Single(unread);
            Assert.Equal("Unread", unread[0].Title);
        }

        private static LibraryService CreateLibraryService(
            TemporaryDirectory directory,
            out NoteService noteService)
        {
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var documentRepository = new DocumentRepository(storage, new AutoTagService());
            noteService = new NoteService(
                new NoteRepository(storage),
                new MarkdownExportService());

            return new LibraryService(documentRepository, noteService);
        }
    }
}
