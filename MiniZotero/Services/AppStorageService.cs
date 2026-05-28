using System;
using System.IO;

namespace MiniZotero.Services
{
    public sealed class AppStorageService
    {
        private const string AppFolderName = "MiniZotero";
        private const string LibraryFileName = "library.json";
        private const string SettingsFileName = "settings.json";
        private const string PdfFolderName = "pdfs";
        private const string NotesFolderName = "notes";
        private const string HighlightsFolderName = "highlights";

        public AppStorageService()
            : this(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                AppFolderName))
        {
        }

        public AppStorageService(string rootPath)
        {
            RootPath = rootPath;

            Directory.CreateDirectory(RootPath);
            Directory.CreateDirectory(PdfFolderPath);
            Directory.CreateDirectory(NotesFolderPath);
            Directory.CreateDirectory(HighlightsFolderPath);
        }

        public string RootPath { get; }

        public string AppDataPath => RootPath;

        public string PdfFolderPath => Path.Combine(RootPath, PdfFolderName);

        public string NotesFolderPath => Path.Combine(RootPath, NotesFolderName);

        public string HighlightsFolderPath => Path.Combine(RootPath, HighlightsFolderName);

        public string LibraryFilePath => Path.Combine(RootPath, LibraryFileName);

        public string SettingsFilePath => Path.Combine(RootPath, SettingsFileName);
    }
}
