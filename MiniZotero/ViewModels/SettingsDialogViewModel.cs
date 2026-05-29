using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.ViewModels
{
    public partial class SettingsDialogViewModel : ViewModelBase
    {
        private readonly IAppSettingsRepository _settingsRepository;
        private readonly Action<AppSettings> _applySettings;
        private readonly Func<Task> _clearTrash;

        public SettingsDialogViewModel(
            AppSettings settings,
            string storageRootPath,
            IAppSettingsRepository settingsRepository,
            Action<AppSettings> applySettings,
            Func<Task> clearTrash)
        {
            _settingsRepository = settingsRepository;
            _applySettings = applySettings;
            _clearTrash = clearTrash;

            WatchFolderPath = settings.WatchFolderPath ?? string.Empty;
            ThemeMode = string.IsNullOrWhiteSpace(settings.ThemeMode)
                ? "System"
                : settings.ThemeMode;
            DefaultPdfZoomPercent = settings.DefaultPdfZoomPercent <= 0
                ? 120
                : settings.DefaultPdfZoomPercent;
            RestorePreviousSession = settings.RestorePreviousSession;
            StorageRootPath = storageRootPath;
        }

        [ObservableProperty]
        private string _watchFolderPath = string.Empty;

        [ObservableProperty]
        private string _themeMode = "System";

        [ObservableProperty]
        private int _defaultPdfZoomPercent = 120;

        [ObservableProperty]
        private bool _restorePreviousSession;

        [ObservableProperty]
        private string _storageRootPath = string.Empty;

        [ObservableProperty]
        private string _statusMessage = "Ready";

        public string[] ThemeModes { get; } = ["System", "Light", "Dark"];

        public event Action<bool>? CloseRequested;

        [RelayCommand]
        private void Save()
        {
            var settings = _settingsRepository.LoadSettings();
            
            settings.WatchFolderPath = string.IsNullOrWhiteSpace(WatchFolderPath)
                ? null
                : WatchFolderPath.Trim();
            settings.ThemeMode = string.IsNullOrWhiteSpace(ThemeMode) ? "System" : ThemeMode;
            settings.DefaultPdfZoomPercent = Math.Clamp(DefaultPdfZoomPercent, 50, 400);
            settings.RestorePreviousSession = RestorePreviousSession;

            _settingsRepository.SaveSettings(settings);
            _applySettings(settings);
            StatusMessage = "Settings saved.";
            CloseRequested?.Invoke(true);
        }

        [RelayCommand]
        private void Cancel()
        {
            CloseRequested?.Invoke(false);
        }

        [RelayCommand]
        private async Task ClearTrash()
        {
            await _clearTrash();
            StatusMessage = "Trash cleared.";
        }
    }
}
