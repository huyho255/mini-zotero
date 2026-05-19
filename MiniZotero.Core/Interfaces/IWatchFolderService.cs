namespace MiniZotero.Core.Interfaces;

public interface IWatchFolderService
{
    void StartWatching(string folderPath);

    void StopWatching();

    bool IsWatching { get; }
}