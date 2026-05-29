using Avalonia.Controls;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class DocumentInfoDialog : Window
    {
        public DocumentInfoDialog()
        {
            InitializeComponent();
        }

        protected override void OnDataContextChanged(System.EventArgs e)
        {
            base.OnDataContextChanged(e);

            if (DataContext is DocumentInfoDialogViewModel vm)
            {
                vm.CloseRequested += (result) => Close(result);
            }
        }
    }
}
