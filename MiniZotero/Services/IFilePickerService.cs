using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public interface IFilePickerService
    {
        Task<IReadOnlyList<string>> PickPdfFilesAsync();

        Task<string?> PickWatchFolderAsync();
    }
}
