using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels;

public class MainWindowViewModel
{
    private readonly AppStorageService _storageService;
    private readonly DocumentRepository _documentRepository;
    private readonly NoteRepository _noteRepository;

    public string AppTitle { get; } = "MiniZotero";

    public SidebarViewModel Sidebar { get; }

    public TabWorkspaceViewModel Workspace { get; } = new();

    public NotePreviewPanelViewModel NotePanel { get; }

    public MainWindowViewModel()
    {
        _storageService = new AppStorageService();

        _documentRepository = new DocumentRepository(_storageService);
        _noteRepository = new NoteRepository(_storageService);

        Sidebar = new SidebarViewModel(_documentRepository);
        NotePanel = new NotePreviewPanelViewModel(_noteRepository);

        Sidebar.DocumentSelected += OnDocumentSelected;
    }

    private void OnDocumentSelected(DocumentItem document)
    {
        Workspace.OpenDocument(document);
        NotePanel.SetActiveDocument(document);
    }
}
