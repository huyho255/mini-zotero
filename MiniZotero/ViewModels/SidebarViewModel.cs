using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.ViewModels;

public class SidebarViewModel : INotifyPropertyChanged
{
    private readonly DocumentRepository _documentRepository;

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
                _selectedDocument.LastOpenedAt = DateTime.Now;
                _documentRepository.SaveDocuments(Documents);

                DocumentSelected?.Invoke(_selectedDocument);
            }
        }
    }

    public SidebarViewModel(DocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
        LoadDocuments();
    }

    public void LoadDocuments()
    {
        Documents.Clear();

        foreach (DocumentItem document in _documentRepository.LoadDocuments())
        {
            Documents.Add(document);
        }

        RefreshDocumentState();
    }

    public void AddDocumentFromFile(string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath))
        {
            return;
        }

        DocumentItem document = _documentRepository.ImportDocument(filePath, Documents);

        bool alreadyInList = Documents.Any(item => item.Id == document.Id);

        if (!alreadyInList)
        {
            Documents.Add(document);
        }

        _documentRepository.SaveDocuments(Documents);

        RefreshDocumentState();
    }

    private void RefreshDocumentState()
    {
        OnPropertyChanged(nameof(HasDocuments));
        OnPropertyChanged(nameof(IsDocumentListEmpty));
    }

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
