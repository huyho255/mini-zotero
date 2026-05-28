using Avalonia.Controls;

namespace MiniZotero.Views
{
    public partial class SidebarView : UserControl
    {
        public SidebarView()
        {
            InitializeComponent();
        }

        private void OnDocumentDoubleTapped(object? sender, Avalonia.Input.TappedEventArgs e)
        {
            if (sender is Avalonia.Controls.Control { DataContext: ViewModels.DocumentExplorerItem { IsDocument: true } item } &&
                DataContext is ViewModels.SidebarViewModel vm)
            {
                vm.RequestOpenDocumentCommand.Execute(item.Document);
            }
        }
    }
}
