using Avalonia.Controls;

namespace MiniZotero.Views
{
    public partial class TabWorkspaceView : UserControl
    {
        public TabWorkspaceView()
        {
            InitializeComponent();
        }

        private void SearchTextBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            if (e.Key == Avalonia.Input.Key.Enter)
            {
                if (DataContext is ViewModels.TabWorkspaceViewModel vm)
                {
                    vm.ActiveTab?.PdfViewer.SearchInPdfCommand.Execute(null);
                }
            }
        }
    }
}
