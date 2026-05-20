using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using MiniZotero.Models;

namespace MiniZotero.ViewModels;

public class SidebarViewModel : INotifyPropertyChanged
{
    private DocumentItem? _selectedDocument;

    public event PropertyChangedEventHandler? PropertyChanged;

    public event Action<DocumentItem>? DocumentSelected;

    public string SearchText { get; set; } = string.Empty;

    public ObservableCollection<DocumentItem> Documents { get; } = new();

    public bool HasDocuments => Documents.Count > 0;

    public bool IsDocumentListEmpty => Documents.Count == 0;

    public string EmptyTitle { get; } = "No documents yet";

    public string EmptyMessage { get; } = "Import a PDF to start";

    public DocumentItem? SelectedDocument
    {
        get => _selectedDocument;
        set
        {
            if (_selectedDocument == value)
            {
                return;
            }

            _selectedDocument = value;
            OnPropertyChanged(nameof(SelectedDocument));

            if (_selectedDocument is not null)
            {
                DocumentSelected?.Invoke(_selectedDocument);
            }
        }
    }

    public void AddDocumentFromFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            return;
        }

        bool alreadyExists = Documents.Any(document => document.FilePath == filePath);

        if (alreadyExists)
        {
            return;
        }

        var document = new DocumentItem
        {
            Id = Guid.NewGuid().ToString(),
            Title = Path.GetFileNameWithoutExtension(filePath),
            FilePath = filePath,
            ImportedAt = DateTime.Now,
            LastReadPage = 0,
            TotalPages = 0,
            IsStarred = false
        };

        Documents.Add(document);

        OnPropertyChanged(nameof(HasDocuments));
        OnPropertyChanged(nameof(IsDocumentListEmpty));
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
