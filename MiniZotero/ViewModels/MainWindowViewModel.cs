using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private readonly IApplicationServices _services;
        private readonly ILibraryService _libraryService;

        [ObservableProperty]
        private string _statusMessage = "Ready";

        public event Action<SettingsDialogViewModel>? OpenSettingsRequested;

        public MainWindowViewModel()
            : this(new ApplicationServices())
        {
        }

        public MainWindowViewModel(IApplicationServices services)
        {
            _services = services;
            _libraryService = services.LibraryService;

            Sidebar = new SidebarViewModel(
                services.LibraryService,
                services.DocumentImportService,
                services.TagService,
                services.CollectionRepository,
                services.CollectionService,
                services.SettingsRepository,
                services.WatchFolderService,
                services.StorageUsageService,
                services.FilePickerService);
            Notes = new NotePreviewPanelViewModel(
                services.NoteService,
                services.HighlightService);
            Workspace = new TabWorkspaceViewModel(document =>
                _libraryService.SaveDocuments(Sidebar.Documents),
                services.PdfService);

            Workspace.HighlightCreated += (text, pageNumber, rects) =>
            {
                Notes.AddHighlightFromViewer(text, pageNumber, rects);
            };

            Notes.HighlightsChanged += () =>
            {
                Workspace.ActivePdfViewer?.LoadHighlightsIntoViewer(Notes.Highlights);
            };

            Notes.HighlightSelected += highlight =>
            {
                Workspace.ActivePdfViewer?.NavigateToHighlight(highlight);
            };

            Notes.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(NotePreviewPanelViewModel.StatusMessage))
                {
                    StatusMessage = Notes.StatusMessage;
                }
            };

            Workspace.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(TabWorkspaceViewModel.ActiveDocument))
                {
                    OnPropertyChanged(nameof(OpenDocumentCount));
                    OnPropertyChanged(nameof(DocumentsOpenText));

                    if (Workspace.ActiveDocument is null)
                    {
                        Notes.ClearDocument();
                    }
                    else
                    {
                        Notes.OpenDocument(Workspace.ActiveDocument);
                        Workspace.ActivePdfViewer?.LoadHighlightsIntoViewer(Notes.Highlights);
                    }
                }
            };

            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.StatusMessage))
                {
                    StatusMessage = Sidebar.StatusMessage;
                }

                if (e.PropertyName == nameof(SidebarViewModel.SelectedDocument) &&
                    Sidebar.SelectedDocument is { } document)
                {
                    ApplyDefaultZoomForUnreadDocument(document);
                    Workspace.OpenDocument(document);
                }
            };
        }

        public SidebarViewModel Sidebar { get; }

        public TabWorkspaceViewModel Workspace { get; }

        public NotePreviewPanelViewModel Notes { get; }

        public int OpenDocumentCount => Workspace.ActiveDocument is null ? 0 : 1;

        public string DocumentsOpenText =>
            OpenDocumentCount == 1
                ? "1 document open"
                : $"{OpenDocumentCount} documents open";

        public string LibraryStatusText => "Local library";

        [RelayCommand]
        private void OpenSettings()
        {
            var settings = _services.SettingsRepository.LoadSettings();
            OpenSettingsRequested?.Invoke(new SettingsDialogViewModel(
                settings,
                _services.StorageService.RootPath,
                _services.SettingsRepository,
                ApplySettings,
                ClearTrash));
        }

        private void ApplySettings(AppSettings settings)
        {
            if (!string.IsNullOrWhiteSpace(settings.WatchFolderPath))
            {
                Sidebar.SetWatchFolder(settings.WatchFolderPath);
            }

            StatusMessage = "Settings saved.";
        }

        private void ApplyDefaultZoomForUnreadDocument(DocumentItem document)
        {
            if (document.LastOpenedAt is not null)
            {
                return;
            }

            var settings = _services.SettingsRepository.LoadSettings();
            document.LastZoomPercent = Math.Clamp(settings.DefaultPdfZoomPercent, 50, 400);
        }

        private void ClearTrash()
        {
            foreach (var document in Sidebar.Documents.Where(document => document.IsDeleted).ToList())
            {
                _libraryService.DeleteForever(document, Sidebar.Documents);
            }

            _libraryService.SaveDocuments(Sidebar.Documents);
            StatusMessage = "Trash cleared.";
        }
    }
}
