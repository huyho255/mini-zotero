using System.Collections.Generic;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class CollectionRepository : ICollectionRepository
    {
        private readonly AppStorageService _storageService;
        private readonly JsonFileStore _jsonFileStore;

        public CollectionRepository(AppStorageService storageService)
            : this(storageService, new JsonFileStore())
        {
        }

        public CollectionRepository(
            AppStorageService storageService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _jsonFileStore = jsonFileStore;
        }

        public IReadOnlyList<CollectionItem> LoadCollections()
        {
            return _jsonFileStore.Load(
                _storageService.CollectionsFilePath,
                new List<CollectionItem>());
        }

        public void SaveCollections(IEnumerable<CollectionItem> collections)
        {
            _jsonFileStore.Save(_storageService.CollectionsFilePath, collections);
        }
    }
}
