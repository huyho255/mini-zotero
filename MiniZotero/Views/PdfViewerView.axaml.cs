using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using MiniZotero.ViewModels;
using System.ComponentModel;

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
            }

            BoundViewModel = DataContext as PdfViewerViewModel;

            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged += OnViewModelPropertyChanged;
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
                if (string.IsNullOrWhiteSpace(e.Body))
                {
                    return;
                }

                PdfViewerMessage? message =
                    JsonSerializer.Deserialize<PdfViewerMessage>(
                        e.Body,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                if (message is null)
                {
                    return;
                }

                viewModel.UpdateReadingStateFromViewer(
                    message.PageNumber,
                    message.ZoomPercent
                );

                if (message.Type == "loaded")
                {
                    ApplyToolMode(viewModel.ToolMode);
                }
            }
            catch
            {
            }
        }

        private sealed class PdfViewerMessage
        {
            [JsonPropertyName("type")]
            public string? Type { get; set; }

            [JsonPropertyName("pageNumber")]
            public int PageNumber { get; set; }

            [JsonPropertyName("zoomPercent")]
            public int ZoomPercent { get; set; }
        }
    }
}
