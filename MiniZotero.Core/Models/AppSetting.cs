namespace MiniZotero.Core.Models;

public class AppSetting
{
    public string LibraryPath { get; set; } = string.Empty;

    public string WatchFolderPath { get; set; } = string.Empty;

    public bool EnableAutoRename { get; set; } = true;

    public bool EnableWatchFolder { get; set; } = false;
}