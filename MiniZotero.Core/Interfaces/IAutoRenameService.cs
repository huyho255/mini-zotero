using MiniZotero.Core.Models;

namespace MiniZotero.Core.Interfaces;

public interface IAutoRenameService
{
    string GenerateFileName(Document document);
}