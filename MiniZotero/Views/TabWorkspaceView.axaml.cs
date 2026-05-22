using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class TabWorkspaceView : UserControl
    {
        public TabWorkspaceView()
        {
            InitializeComponent();
        }

        private void OnHandToolClicked(object? sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            if (DataContext is TabWorkspaceViewModel viewModel)
            {
                viewModel.PdfViewer.SetHandTool();
            }
        }

        private void OnSelectToolClicked(object? sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            if (DataContext is TabWorkspaceViewModel viewModel)
            {
                viewModel.PdfViewer.SetSelectTool();
            }
        }
    }
}
