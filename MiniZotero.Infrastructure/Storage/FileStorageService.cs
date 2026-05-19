using MiniZotero.Core.Interfaces;

namespace MiniZotero.Infrastructure.Storage;

public class FileStorageService : IFileStorageService
{
    private readonly string _libraryFolderPath;

    public FileStorageService()
    {
        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        _libraryFolderPath = Path.Combine(documentsPath, "MiniZoteroLibrary");

        if (!Directory.Exists(_libraryFolderPath))
        {
            Directory.CreateDirectory(_libraryFolderPath);
        }
    }

    public string SaveFile(string sourceFilePath)
    {
        if (!File.Exists(sourceFilePath))
        {
            throw new FileNotFoundException("Source file not found.", sourceFilePath);
        }

        string fileName = Path.GetFileName(sourceFilePath);
        string destinationPath = Path.Combine(_libraryFolderPath, fileName);

        if (File.Exists(destinationPath))
        {
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
            string extension = Path.GetExtension(fileName);
            string uniqueName = $"{fileNameWithoutExtension}_{DateTime.Now:yyyyMMddHHmmss}{extension}";

            destinationPath = Path.Combine(_libraryFolderPath, uniqueName);
        }

        File.Copy(sourceFilePath, destinationPath);

        return destinationPath;
    }

    public void DeleteFile(string storedFilePath)
    {
        if (File.Exists(storedFilePath))
        {
            File.Delete(storedFilePath);
        }
    }

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }
}