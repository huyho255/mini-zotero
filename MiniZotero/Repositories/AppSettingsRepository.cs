using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class AppSettingsRepository
    {
        private readonly AppStorageService _storageService;
        private readonly JsonFileStore _jsonFileStore;

        public AppSettingsRepository(AppStorageService storageService)
            : this(storageService, new JsonFileStore())
        {
        }

        public AppSettingsRepository(
            AppStorageService storageService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _jsonFileStore = jsonFileStore;
        }

        public AppSettings LoadSettings()
        {
            return _jsonFileStore.Load(_storageService.SettingsFilePath, new AppSettings());
        }

        public void SaveSettings(AppSettings settings)
        {
            _jsonFileStore.Save(_storageService.SettingsFilePath, settings);
        }
    }
}
