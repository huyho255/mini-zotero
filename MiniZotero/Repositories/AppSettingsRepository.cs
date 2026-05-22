using System.IO;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class AppSettingsRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;

        public AppSettingsRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public AppSettings LoadSettings()
        {
            if (!File.Exists(_storageService.SettingsFilePath))
            {
                return new AppSettings();
            }

            try
            {
                var json = File.ReadAllText(_storageService.SettingsFilePath);
                return JsonSerializer.Deserialize<AppSettings>(json, JsonOptions) ?? new AppSettings();
            }
            catch
            {
                return new AppSettings();
            }
        }

        public void SaveSettings(AppSettings settings)
        {
            var json = JsonSerializer.Serialize(settings, JsonOptions);
            File.WriteAllText(_storageService.SettingsFilePath, json);
        }
    }
}
