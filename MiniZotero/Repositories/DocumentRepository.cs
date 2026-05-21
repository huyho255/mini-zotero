using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories;

public class DocumentRepository
{
    private readonly AppStorageService _storage;

    private readonly JsonSerializerOptions _jsonOptions = new()
    {
        WriteIndented = true
    };

    public DocumentRepository(AppStorageService storage)
    {
        _storage = storage;
    }

    public List<DocumentItem> LoadDocuments()
    {
        if (!File.Exists(_storage.LibraryFilePath))
        {
            return new List<DocumentItem>();
        }

        string json = File.ReadAllText(_storage.LibraryFilePath);

        if (string.IsNullOrWhiteSpace(json))
        {
            return new List<DocumentItem>();
        }

        return JsonSerializer.Deserialize<List<DocumentItem>>(json) ?? new List<DocumentItem>();
    }

    public void SaveDocuments(IEnumerable<DocumentItem> documents)
    {
        string json = JsonSerializer.Serialize(documents.ToList(), _jsonOptions);
        File.WriteAllText(_storage.LibraryFilePath, json);
    }

    public DocumentItem ImportDocument(string sourceFilePath, IEnumerable<DocumentItem> existingDocuments)
    {
        if (!File.Exists(sourceFilePath))
        {
            throw new FileNotFoundException("PDF file not found.", sourceFilePath);
        }

        DocumentItem? existing = existingDocuments.FirstOrDefault(document =>
            string.Equals(document.OriginalFilePath, sourceFilePath, StringComparison.OrdinalIgnoreCase)
            || string.Equals(document.FilePath, sourceFilePath, StringComparison.OrdinalIgnoreCase)
        );

        if (existing is not null)
        {
            return existing;
        }

        string documentId = Guid.NewGuid().ToString();
        string title = Path.GetFileNameWithoutExtension(sourceFilePath);
        string destinationFilePath = Path.Combine(_storage.PdfFolderPath, $"{documentId}.pdf");

        File.Copy(sourceFilePath, destinationFilePath, overwrite: true);

        return new DocumentItem
        {
            Id = documentId,
            Title = title,
            FilePath = destinationFilePath,
            OriginalFilePath = sourceFilePath,
            ImportedAt = DateTime.Now,
            LastOpenedAt = null,
            LastReadPage = 1,
            TotalPages = 0,
            IsStarred = false
        };
    }
}
