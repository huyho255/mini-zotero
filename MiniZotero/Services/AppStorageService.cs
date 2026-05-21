using System;
using System.IO;

namespace MiniZotero.Services
{
    public sealed class AppStorageService
    {
        private const string AppFolderName = "MiniZotero";
        private const string LibraryFileName = "library.json";
        private const string PdfFolderName = "pdfs";

        public AppStorageService()
        {
            RootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                AppFolderName);

            Directory.CreateDirectory(RootPath);
            Directory.CreateDirectory(PdfFolderPath);
        }

        public string RootPath { get; }

        public string AppDataPath => RootPath;

        public string PdfFolderPath => Path.Combine(RootPath, PdfFolderName);

        public string LibraryFilePath => Path.Combine(RootPath, LibraryFileName);
    }
}
