using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Core.Services;

public class AutoRenameService : IAutoRenameService
{
    public string GenerateFileName(Document document)
    {
        string title = string.IsNullOrWhiteSpace(document.Title)
            ? "Untitled"
            : document.Title;

        string safeTitle = MakeSafeFileName(title);

        string extension = document.FileType.ToLower();

        if (string.IsNullOrWhiteSpace(extension))
        {
            extension = "pdf";
        }

        return $"{safeTitle}.{extension}";
    }

    private string MakeSafeFileName(string fileName)
    {
        foreach (char c in Path.GetInvalidFileNameChars())
        {
            fileName = fileName.Replace(c, '_');
        }

        return fileName.Trim();
    }
}