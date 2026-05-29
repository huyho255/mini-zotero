using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class DocumentInfoDialogViewModel : ViewModelBase
    {
        private readonly DocumentItem _document;
        private readonly Action<DocumentItem> _saveAction;

        public event Action<bool>? CloseRequested;

        public DocumentInfoDialogViewModel(DocumentItem document, Action<DocumentItem> saveAction)
        {
            _document = document;
            _saveAction = saveAction;

            Title = document.Title;
            Authors = string.Join(", ", document.Authors);
            Year = document.Year?.ToString() ?? string.Empty;
            Doi = document.Doi ?? string.Empty;
            JournalOrPublisher = document.JournalOrPublisher ?? string.Empty;
            Abstract = document.Abstract ?? string.Empty;
            DocumentType = document.DocumentType ?? string.Empty;
            
            OriginalFilePath = document.OriginalFilePath;
            AddedAt = document.AddedAt.ToString("g");
        }

        [ObservableProperty]
        private string _title = string.Empty;

        [ObservableProperty]
        private string _authors = string.Empty;

        [ObservableProperty]
        private string _year = string.Empty;

        [ObservableProperty]
        private string _doi = string.Empty;

        [ObservableProperty]
        private string _journalOrPublisher = string.Empty;

        [ObservableProperty]
        private string _abstract = string.Empty;

        [ObservableProperty]
        private string _documentType = string.Empty;

        public string OriginalFilePath { get; }
        
        public string AddedAt { get; }

        [RelayCommand]
        private void Save()
        {
            _document.Title = Title;
            _document.Authors = [.. Authors.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)];
            
            if (int.TryParse(Year, out var yearResult))
            {
                _document.Year = yearResult;
            }
            else
            {
                _document.Year = null;
            }

            _document.Doi = string.IsNullOrWhiteSpace(Doi) ? null : Doi.Trim();
            _document.JournalOrPublisher = string.IsNullOrWhiteSpace(JournalOrPublisher) ? null : JournalOrPublisher.Trim();
            _document.Abstract = string.IsNullOrWhiteSpace(Abstract) ? null : Abstract.Trim();
            _document.DocumentType = string.IsNullOrWhiteSpace(DocumentType) ? null : DocumentType.Trim();

            _saveAction(_document);
            CloseRequested?.Invoke(true);
        }

        [RelayCommand]
        private void Cancel()
        {
            CloseRequested?.Invoke(false);
        }
    }
}
