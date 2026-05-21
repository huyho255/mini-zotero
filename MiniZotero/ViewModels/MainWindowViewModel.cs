namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.SelectedDocument) &&
                    Sidebar.SelectedDocument is { } document)
                {
                    Workspace.OpenDocument(document);
                    Notes.OpenDocument(document);
                }
            };
        }

        public SidebarViewModel Sidebar { get; } = new();

        public TabWorkspaceViewModel Workspace { get; } = new();

        public NotePreviewPanelViewModel Notes { get; } = new();
    }
}
