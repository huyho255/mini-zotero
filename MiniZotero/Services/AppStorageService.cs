using System;
using System.IO;

namespace MiniZotero.Services;

public class AppStorageService
{
    public string RootPath { get; }

    public string PdfFolderPath => Path.Combine(RootPath, "pdfs");

    public string NotesFolderPath => Path.Combine(RootPath, "notes");

    public string LibraryFilePath => Path.Combine(RootPath, "library.json");

    public string HighlightsFilePath => Path.Combine(RootPath, "highlights.json");

    public string SettingsFilePath => Path.Combine(RootPath, "settings.json");

    public AppStorageService()
    {
        RootPath = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "MiniZotero"
        );

        EnsureCreated();
    }

    private void EnsureCreated()
    {
        Directory.CreateDirectory(RootPath);
        Directory.CreateDirectory(PdfFolderPath);
        Directory.CreateDirectory(NotesFolderPath);

        if (!File.Exists(LibraryFilePath))
        {
            File.WriteAllText(LibraryFilePath, "[]");
        }

        if (!File.Exists(HighlightsFilePath))
        {
            File.WriteAllText(HighlightsFilePath, "[]");
        }
    }
}
