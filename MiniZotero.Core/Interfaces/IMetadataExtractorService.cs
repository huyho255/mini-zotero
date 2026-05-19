using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface IMetadataExtractorService
{
    Document ExtractMetadata(string filePath);
}