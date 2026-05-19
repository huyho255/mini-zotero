using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface ISearchService
{
    List<Document> SearchByKeyword(string keyword);

    List<Document> SearchByTag(string tagName);

    List<Document> SearchByFileType(string fileType);
}