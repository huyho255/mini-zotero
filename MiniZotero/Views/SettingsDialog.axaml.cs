using Avalonia.Controls;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class SettingsDialog : Window
    {
        public SettingsDialog()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private SettingsDialogViewModel? BoundViewModel { get; set; }

        private void OnDataContextChanged(object? sender, System.EventArgs e)
        {
            if (BoundViewModel is not null)
            {
                BoundViewModel.CloseRequested -= OnCloseRequested;
            }

            BoundViewModel = DataContext as SettingsDialogViewModel;

            if (BoundViewModel is not null)
            {
                BoundViewModel.CloseRequested += OnCloseRequested;
            }
        }

        private void OnCloseRequested(bool result)
        {
            Close(result);
        }
    }
}
