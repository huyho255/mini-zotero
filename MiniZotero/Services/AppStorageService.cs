using System;
using System.IO;

namespace MiniZotero.Services
{
    public sealed class AppStorageService
    {
        private const string AppFolderName = "MiniZotero";
        private const string LibraryFileName = "library.json";

        public AppStorageService()
        {
            AppDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                AppFolderName);

            Directory.CreateDirectory(AppDataPath);
        }

        public string AppDataPath { get; }

        public string LibraryFilePath => Path.Combine(AppDataPath, LibraryFileName);
    }
}
