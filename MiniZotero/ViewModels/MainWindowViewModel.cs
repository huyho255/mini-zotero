using System;
using System.Linq;
using System.Threading.Tasks;
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
        private bool _isRestoringWorkspace;

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

            Workspace.ToggleStarRequested += document =>
            {
                Sidebar.ToggleStarCommand.Execute(document);
            };

            Notes.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(NotePreviewPanelViewModel.StatusMessage))
                {
                    StatusMessage = Notes.StatusMessage;
                }
            };

            Workspace.OpenTabs.CollectionChanged += (_, _) => SaveWorkspaceState();

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

                    SaveWorkspaceState();
                }
            };

            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.StatusMessage))
                {
                    StatusMessage = Sidebar.StatusMessage;
                }
            };

            Sidebar.OpenDocumentRequested += document =>
            {
                ApplyDefaultZoomForUnreadDocument(document);
                Workspace.OpenDocument(document);
            };

            RestoreWorkspaceState();
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

        private async Task ClearTrash()
        {
            await _libraryService.EmptyTrashAsync(Sidebar.Documents);
            Sidebar.RefreshAfterDocumentChange();
            StatusMessage = "Trash cleared.";
        }

        private void RestoreWorkspaceState()
        {
            var settings = _services.SettingsRepository.LoadSettings();
            if (!settings.RestorePreviousSession || settings.OpenDocumentIds.Count == 0)
            {
                return;
            }

            _isRestoringWorkspace = true;

            try
            {
                var openDocuments = Sidebar.Documents
                    .Where(d => settings.OpenDocumentIds.Contains(d.Id))
                    .ToList();

                foreach (var id in settings.OpenDocumentIds)
                {
                    var doc = openDocuments.FirstOrDefault(d => d.Id == id);
                    if (doc is not null)
                    {
                        Workspace.OpenDocument(doc);
                    }
                }

                if (!string.IsNullOrEmpty(settings.ActiveDocumentId))
                {
                    var activeTab = Workspace.OpenTabs.FirstOrDefault(t => t.Document.Id == settings.ActiveDocumentId);
                    if (activeTab is not null)
                    {
                        Workspace.SetActiveTabCommand.Execute(activeTab);
                    }
                }
            }
            finally
            {
                _isRestoringWorkspace = false;
            }
        }

        private void SaveWorkspaceState()
        {
            if (_isRestoringWorkspace)
            {
                return;
            }

            var settings = _services.SettingsRepository.LoadSettings();
            settings.OpenDocumentIds = Workspace.OpenTabs.Select(t => t.Document.Id).ToList();
            settings.ActiveDocumentId = Workspace.ActiveDocument?.Id;
            _services.SettingsRepository.SaveSettings(settings);
        }
    }
}
