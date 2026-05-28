using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class CollectionServiceTests
    {
        [Fact]
        public void CreateRenameAndDeleteCollection()
        {
            var service = new CollectionService();
            var collections = new[]
            {
                new CollectionItem { Name = "Papers" }
            }.ToList();

            var collection = service.CreateCollection("Papers", collections);
            collections.Add(collection);

            Assert.Equal("Papers 2", collection.Name);

            service.RenameCollection(collection, "Archive", collections);

            Assert.Equal("Archive", collection.Name);

            service.DeleteCollection(collection, collections);

            Assert.DoesNotContain(collection, collections);
        }

        [Fact]
        public void AddAndRemoveDocumentFromCollection()
        {
            var service = new CollectionService();
            var document = new DocumentItem { Id = "doc-1", Title = "Document" };
            var collection = new CollectionItem { Name = "Papers" };

            service.AddDocumentToCollection(document, collection);
            service.AddDocumentToCollection(document, collection);

            Assert.Single(collection.DocumentIds);

            service.RemoveDocumentFromCollection(document, collection);

            Assert.Empty(collection.DocumentIds);
        }

        [Fact]
        public void RepositorySavesAndLoadsCollections()
        {
            using var temporaryDirectory = new TemporaryDirectory();
            var storageService = new AppStorageService(temporaryDirectory.Path);
            var repository = new CollectionRepository(storageService);
            var collections = new[]
            {
                new CollectionItem
                {
                    Name = "Papers",
                    DocumentIds = ["doc-1"]
                }
            };

            repository.SaveCollections(collections);
            var loadedCollections = repository.LoadCollections();

            Assert.Single(loadedCollections);
            Assert.Equal("Papers", loadedCollections[0].Name);
            Assert.Equal("doc-1", loadedCollections[0].DocumentIds[0]);
        }
    }
}
