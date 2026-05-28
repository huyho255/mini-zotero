using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class StorageUsageService
    {
        public long GetLibraryUsageBytes(IEnumerable<DocumentItem> documents)
        {
            return documents
                .Where(document => !document.IsDeleted)
                .Sum(GetDocumentFileSize);
        }

        public string FormatByteCount(long bytes)
        {
            string[] units = ["B", "KB", "MB", "GB", "TB"];
            var size = (double)Math.Max(bytes, 0);
            var unitIndex = 0;

            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }

            return unitIndex == 0
                ? $"{size:0} {units[unitIndex]}"
                : $"{size:0.#} {units[unitIndex]}";
        }

        private static long GetDocumentFileSize(DocumentItem document)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(document.FilePath) && File.Exists(document.FilePath)
                    ? new FileInfo(document.FilePath).Length
                    : 0;
            }
            catch (IOException)
            {
                return 0;
            }
            catch (UnauthorizedAccessException)
            {
                return 0;
            }
        }
    }
}
