using System.ComponentModel;
using Avalonia.Controls;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class PdfViewerView : UserControl
    {
        public PdfViewerView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private PdfViewerViewModel? BoundViewModel { get; set; }

        private void OnDataContextChanged(object? sender, System.EventArgs e)
        {
            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged -= OnViewModelPropertyChanged;
                BoundViewModel.ScriptRequested -= OnScriptRequested;
            }

            BoundViewModel = DataContext as PdfViewerViewModel;

            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged += OnViewModelPropertyChanged;
                BoundViewModel.ScriptRequested += OnScriptRequested;
                ApplyToolMode(BoundViewModel.ToolMode);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PdfViewerViewModel.ToolMode) &&
                BoundViewModel is not null)
            {
                ApplyToolMode(BoundViewModel.ToolMode);
            }
        }

        private void OnScriptRequested(string script)
        {
            try
            {
                _ = PdfWebView.InvokeScript(script);
            }
            catch
            {
            }
        }

        private void ApplyToolMode(string toolMode)
        {
            try
            {
                _ = PdfWebView.InvokeScript(
                    $"window.miniZoteroPdf?.setToolMode?.('{toolMode}');"
                );
            }
            catch
            {
            }
        }

        private void OnPdfWebViewMessageReceived(
            object? sender,
            WebMessageReceivedEventArgs e
        )
        {
            if (DataContext is not PdfViewerViewModel viewModel)
            {
                return;
            }

            try
            {
                viewModel.ProcessViewerMessage(e.Body);
            }
            catch
            {
            }
        }
    }
}
