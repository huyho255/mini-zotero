using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class TabWorkspaceViewModel : ViewModelBase
    {
        private static readonly IPdfService DefaultPdfService = new PdfService();
        private readonly Action<DocumentItem> _persistReadingState;
        private readonly IPdfService _pdfService;

        public TabWorkspaceViewModel()
            : this(_ => { })
        {
        }

        public TabWorkspaceViewModel(Action<DocumentItem> persistReadingState)
            : this(persistReadingState, DefaultPdfService)
        {
        }

        public TabWorkspaceViewModel(
            Action<DocumentItem> persistReadingState,
            IPdfService pdfService)
        {
            _persistReadingState = persistReadingState;
            _pdfService = pdfService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        [NotifyPropertyChangedFor(nameof(ActiveDocument))]
        [NotifyPropertyChangedFor(nameof(ActivePdfViewer))]
        [NotifyPropertyChangedFor(nameof(ActiveDocumentIsStarred))]
        [NotifyPropertyChangedFor(nameof(ActiveDocumentStarIcon))]
        private DocumentTabViewModel? _activeTab;

        partial void OnActiveTabChanged(DocumentTabViewModel? oldValue, DocumentTabViewModel? newValue)
        {
            if (oldValue is not null)
            {
                oldValue.IsActive = false;
            }

            if (newValue is not null)
            {
                newValue.IsActive = true;
            }
        }

        public ObservableCollection<DocumentTabViewModel> OpenTabs { get; } = new();

        public DocumentItem? ActiveDocument => ActiveTab?.Document;

        public PdfViewerViewModel? ActivePdfViewer => ActiveTab?.PdfViewer;

        public bool IsEmptyViewVisible => ActiveTab is null;

        public bool ActiveDocumentIsStarred => ActiveDocument?.IsStarred == true;

        public string ActiveDocumentStarIcon => ActiveDocumentIsStarred ? "\uE735" : "\uE734";

        public event Action<string, int, System.Collections.Generic.IReadOnlyList<HighlightRect>>? HighlightCreated;
        
        public event Action<DocumentItem>? ToggleStarRequested;

        public void OpenDocument(DocumentItem document)
        {
            var existingTab = OpenTabs.FirstOrDefault(tab =>
                string.Equals(tab.Document.Id, document.Id, StringComparison.OrdinalIgnoreCase));

            if (existingTab is not null)
            {
                ActiveTab = existingTab;
                return;
            }

            var tab = new DocumentTabViewModel(document, _persistReadingState, _pdfService);
            tab.PdfViewer.HighlightCreated += OnTabHighlightCreated;
            OpenTabs.Add(tab);
            ActiveTab = tab;
        }

        public void CloseTab(DocumentTabViewModel? tab)
        {
            if (tab is null)
            {
                return;
            }

            var tabIndex = OpenTabs.IndexOf(tab);
            tab.PdfViewer.HighlightCreated -= OnTabHighlightCreated;
            tab.PdfViewer.ClearDocument();
            OpenTabs.Remove(tab);

            if (ActiveTab != tab)
            {
                return;
            }

            if (OpenTabs.Count == 0)
            {
                ActiveTab = null;
                return;
            }

            ActiveTab = OpenTabs[Math.Clamp(tabIndex, 0, OpenTabs.Count - 1)];
        }

        [RelayCommand]
        private void SetActiveTab(DocumentTabViewModel? tab)
        {
            if (tab is not null)
            {
                ActiveTab = tab;
            }
        }

        public void MoveTab(DocumentTabViewModel tab, int newIndex)
        {
            if (tab is null || newIndex < 0 || newIndex >= OpenTabs.Count)
            {
                return;
            }

            var oldIndex = OpenTabs.IndexOf(tab);
            if (oldIndex < 0 || oldIndex == newIndex)
            {
                return;
            }

            OpenTabs.Move(oldIndex, newIndex);
            ActiveTab = tab;
        }

        [RelayCommand]
        private void ToggleStar()
        {
            if (ActiveDocument is not null)
            {
                ToggleStarRequested?.Invoke(ActiveDocument);
                OnPropertyChanged(nameof(ActiveDocumentIsStarred));
                OnPropertyChanged(nameof(ActiveDocumentStarIcon));
            }
        }

        [RelayCommand]
        private void CloseDocumentTab(DocumentTabViewModel? tab)
        {
            CloseTab(tab);
        }

        [RelayCommand]
        private void CloseActiveDocument()
        {
            CloseTab(ActiveTab);
        }

        [RelayCommand]
        private void CloseAllTabs()
        {
            ClearAllTabs();
        }

        public void ClearAllTabs()
        {
            foreach (var tab in OpenTabs.ToList())
            {
                CloseTab(tab);
            }
        }

        private void OnTabHighlightCreated(
            string text,
            int pageNumber,
            System.Collections.Generic.IReadOnlyList<HighlightRect> rects)
        {
            HighlightCreated?.Invoke(text, pageNumber, rects);
        }
    }
}
