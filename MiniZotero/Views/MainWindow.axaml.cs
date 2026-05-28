using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private MainWindowViewModel? BoundViewModel { get; set; }

        private void OnDataContextChanged(object? sender, EventArgs e)
        {
            if (BoundViewModel is not null)
            {
                BoundViewModel.OpenSettingsRequested -= OnOpenSettingsRequested;
            }

            BoundViewModel = DataContext as MainWindowViewModel;

            if (BoundViewModel is not null)
            {
                BoundViewModel.OpenSettingsRequested += OnOpenSettingsRequested;
            }
        }

        private async void OnOpenSettingsRequested(SettingsDialogViewModel viewModel)
        {
            var dialog = new SettingsDialog
            {
                DataContext = viewModel
            };

            await dialog.ShowDialog<bool>(this);
        }

        private void OnTabStripPointerWheelChanged(object? sender, PointerWheelEventArgs e)
        {
            var scrollDelta = Math.Abs(e.Delta.X) > 0
                ? -e.Delta.X
                : -e.Delta.Y;

            if (Math.Abs(scrollDelta) == 0)
            {
                return;
            }

            var maximumOffset = Math.Max(
                0,
                TabStripScrollViewer.Extent.Width - TabStripScrollViewer.Viewport.Width);
            var nextOffset = Math.Clamp(
                TabStripScrollViewer.Offset.X + scrollDelta * 64,
                0,
                maximumOffset);

            TabStripScrollViewer.Offset = new Vector(
                nextOffset,
                TabStripScrollViewer.Offset.Y);
            e.Handled = true;
        }
    }
}
