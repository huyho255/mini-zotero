using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using MiniZotero.Models;
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

                if (message.Type == "highlightCreated")
                {
                    viewModel.AddHighlightFromViewer(
                        message.Text ?? string.Empty,
                        message.PageNumber,
                        message.Rects ?? []);

                    return;
                }

                viewModel.UpdateReadingStateFromViewer(
                    message.PageNumber,
                    message.ZoomPercent
                );

                if (message.Type == "loaded")
                {
                    ApplyToolMode(viewModel.ToolMode);
                    viewModel.SendHighlightsToViewer();
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

            [JsonPropertyName("text")]
            public string? Text { get; set; }

            [JsonPropertyName("rects")]
            public List<HighlightRect>? Rects { get; set; }
        }
    }
}
