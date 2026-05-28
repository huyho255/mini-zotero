using System;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class RepositoryAndServiceTests
    {
        [Fact]
        public void ImportDocumentCopiesPdfAndDoesNotDuplicateExistingDocument()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new DocumentRepository(storage, new AutoTagService());
            var sourcePath = Path.Combine(directory.Path, "Class.pdf");
            File.WriteAllBytes(sourcePath, [1, 2, 3]);

            var firstDocument = repository.ImportDocument(sourcePath, []);
            var secondDocument = repository.ImportDocument(sourcePath, [firstDocument]);

            Assert.Equal(firstDocument.Id, secondDocument.Id);
            Assert.True(File.Exists(firstDocument.FilePath));
            Assert.StartsWith(storage.PdfFolderPath, firstDocument.FilePath, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void HighlightRepositoryAddsDeletesSavesAndLoadsByDocumentId()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new HighlightRepository(storage);
            var firstHighlight = new HighlightItem
            {
                DocumentId = "doc-1",
                Text = "First"
            };
            var secondHighlight = new HighlightItem
            {
                DocumentId = "doc-2",
                Text = "Second"
            };

            repository.AddHighlight(firstHighlight);
            repository.AddHighlight(secondHighlight);
            repository.DeleteHighlight("doc-1", firstHighlight.Id);

            Assert.Empty(repository.LoadHighlights("doc-1"));
            Assert.Single(repository.LoadHighlights("doc-2"));
        }

        [Fact]
        public void NoteRepositorySanitizesDocumentIdAndReturnsEmptyTextForMissingNote()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new NoteRepository(storage);

            repository.SaveNote("bad:id", "hello");

            Assert.Equal("hello", repository.LoadNote("bad:id"));
            Assert.Equal(string.Empty, repository.LoadNote("missing"));
            Assert.True(File.Exists(Path.Combine(storage.NotesFolderPath, "bad_id.md")));
        }

        [Fact]
        public void MarkdownExportOrdersHighlightsByPage()
        {
            using var directory = new TemporaryDirectory();
            var service = new MarkdownExportService();
            var document = new DocumentItem(
                "doc",
                "Document",
                "stored.pdf",
                "source.pdf",
                new DateTimeOffset(2026, 5, 28, 10, 0, 0, TimeSpan.Zero),
                lastOpenedAt: null,
                lastReadPage: 1);
            var outputPath = Path.Combine(directory.Path, "notes.md");
            var highlights = new[]
            {
                new HighlightItem { DocumentId = "doc", PageNumber = 3, Text = "Third" },
                new HighlightItem { DocumentId = "doc", PageNumber = 1, Text = "First" }
            };

            service.ExportDocumentNotes(document, "note", highlights, outputPath);

            var markdown = File.ReadAllText(outputPath);

            Assert.True(markdown.IndexOf("### Page 1", StringComparison.Ordinal) <
                        markdown.IndexOf("### Page 3", StringComparison.Ordinal));
        }

        [Fact]
        public void StorageUsageServiceCountsActiveExistingDocumentsOnly()
        {
            using var directory = new TemporaryDirectory();
            var activePath = Path.Combine(directory.Path, "active.pdf");
            var deletedPath = Path.Combine(directory.Path, "deleted.pdf");
            File.WriteAllBytes(activePath, [1, 2, 3, 4]);
            File.WriteAllBytes(deletedPath, [1, 2, 3, 4, 5]);
            var service = new StorageUsageService();
            var documents = new[]
            {
                new DocumentItem { FilePath = activePath },
                new DocumentItem { FilePath = deletedPath, IsDeleted = true },
                new DocumentItem { FilePath = Path.Combine(directory.Path, "missing.pdf") }
            };

            var bytes = service.GetLibraryUsageBytes(documents);

            Assert.Equal(4, bytes);
            Assert.Equal("4 B", service.FormatByteCount(bytes));
        }
    }
}
