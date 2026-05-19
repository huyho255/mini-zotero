using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Core.Services;

public class MetadataExtractorService : IMetadataExtractorService
{
    public Document ExtractMetadata(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath)
            .Replace(".", "")
            .ToUpper();

        return new Document
        {
            Title = fileName,
            FilePath = filePath,
            FileType = extension,
            ImportedAt = DateTime.Now
        };
    }
}