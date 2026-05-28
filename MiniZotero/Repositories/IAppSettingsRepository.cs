using MiniZotero.Models;

namespace MiniZotero.Repositories
{
    public interface IAppSettingsRepository
    {
        AppSettings LoadSettings();

        void SaveSettings(AppSettings settings);
    }
}