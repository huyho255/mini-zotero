namespace MiniZotero.Core.Interfaces;

public interface IFileStorageService
{
    string SaveFile(string sourceFilePath);

    void DeleteFile(string storedFilePath);

    bool FileExists(string filePath);
}