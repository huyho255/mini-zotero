using MiniZotero.Core.Interfaces;
using MiniZotero.Core.Models;

namespace MiniZotero.Core.Services;

public class SearchService : ISearchService
{
    private readonly IDocumentRepository _documentRepository;

    public SearchService(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public List<Document> SearchByKeyword(string keyword)
    {
        List<Document> documents = _documentRepository.GetAll();

        if (string.IsNullOrWhiteSpace(keyword))
        {
            return documents;
        }

        keyword = keyword.ToLower();

        return documents
            .Where(d =>
                d.Title.ToLower().Contains(keyword) ||
                d.FileType.ToLower().Contains(keyword) ||
                d.Authors.Any(a => a.FullName.ToLower().Contains(keyword)) ||
                d.Tags.Any(t => t.Name.ToLower().Contains(keyword)))
            .ToList();
    }

    public List<Document> SearchByTag(string tagName)
    {
        List<Document> documents = _documentRepository.GetAll();

        if (string.IsNullOrWhiteSpace(tagName))
        {
            return documents;
        }

        return documents
            .Where(d => d.Tags.Any(t =>
                t.Name.Equals(tagName, StringComparison.OrdinalIgnoreCase)))
            .ToList();
    }

    public List<Document> SearchByFileType(string fileType)
    {
        List<Document> documents = _documentRepository.GetAll();

        if (string.IsNullOrWhiteSpace(fileType))
        {
            return documents;
        }

        return documents
            .Where(d =>
                d.FileType.Equals(fileType, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}