using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Core.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IFileStorageService _fileStorageService;
    private readonly IMetadataExtractorService _metadataExtractorService;

    public DocumentService(
        IDocumentRepository documentRepository,
        IFileStorageService fileStorageService,
        IMetadataExtractorService metadataExtractorService)
    {
        _documentRepository = documentRepository;
        _fileStorageService = fileStorageService;
        _metadataExtractorService = metadataExtractorService;
    }

    public Document ImportDocument(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path is empty.");
        }

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File not found.", filePath);
        }

        string extension = Path.GetExtension(filePath).ToLower();

        if (extension != ".pdf" && extension != ".epub")
        {
            throw new InvalidOperationException("MiniZotero only supports PDF and EPUB files.");
        }

        string storedFilePath = _fileStorageService.SaveFile(filePath);

        Document document = _metadataExtractorService.ExtractMetadata(storedFilePath);

        _documentRepository.Add(document);

        return document;
    }

    public List<Document> GetAllDocuments()
    {
        return _documentRepository.GetAll();
    }

    public Document? GetDocumentById(Guid id)
    {
        return _documentRepository.GetById(id);
    }

    public void DeleteDocument(Guid id)
    {
        Document? document = _documentRepository.GetById(id);

        if (document == null)
        {
            return;
        }

        if (!string.IsNullOrWhiteSpace(document.FilePath))
        {
            _fileStorageService.DeleteFile(document.FilePath);
        }

        _documentRepository.Delete(id);
    }

    public void AddTag(Guid documentId, string tagName)
    {
        Document? document = _documentRepository.GetById(documentId);

        if (document == null)
        {
            return;
        }

        bool tagExists = document.Tags.Any(t =>
            t.Name.Equals(tagName, StringComparison.OrdinalIgnoreCase));

        if (!tagExists)
        {
            document.Tags.Add(new Tag
            {
                Name = tagName
            });

            _documentRepository.Update(document);
        }
    }

    public void AddNote(Guid documentId, string markdownContent)
    {
        Document? document = _documentRepository.GetById(documentId);

        if (document == null)
        {
            return;
        }

        document.Notes.Add(new Note
        {
            DocumentId = documentId,
            MarkdownContent = markdownContent,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        });

        _documentRepository.Update(document);
    }
}