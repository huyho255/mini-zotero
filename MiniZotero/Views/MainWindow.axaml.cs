using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Avalonia.Layout;
using Avalonia.Interactivity;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
            AddHandler(DragDrop.DragOverEvent, OnGlobalDragOver, RoutingStrategies.Tunnel);
        }

        private Point _currentDragVisualOffset;

        public void ShowDragVisual(string title, Point offset, bool isSidebarDrag)
        {
            ClearDragVisual();
            _currentDragVisualOffset = offset;
            
            var border = new Border
            {
                Background = new SolidColorBrush(Color.Parse("#1E293B")),
                BorderBrush = new SolidColorBrush(Color.Parse("#334155")),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(6),
                Padding = new Thickness(12, 8),
                Child = new TextBlock
                {
                    Text = title,
                    Foreground = new SolidColorBrush(Color.Parse("#F8FAFC")),
                    FontSize = 12,
                    FontWeight = FontWeight.SemiBold
                },
                Opacity = 0.85
            };
            
            DragVisualLayer.Children.Add(border);

            if (isSidebarDrag)
            {
                TabWorkspace.IsVisible = false;
                DropZoneOverlay.IsVisible = true;
            }
        }

        public void ClearDragVisual()
        {
            DragVisualLayer.Children.Clear();
            TabWorkspace.IsVisible = true;
            DropZoneOverlay.IsVisible = false;
        }

        private void OnGlobalDragOver(object? sender, DragEventArgs e)
        {
            if (DragVisualLayer.Children.Count > 0)
            {
                var visual = DragVisualLayer.Children[0];
                var pos = e.GetPosition(DragVisualLayer);
                Canvas.SetLeft(visual, pos.X - _currentDragVisualOffset.X);
                Canvas.SetTop(visual, pos.Y - _currentDragVisualOffset.Y);
            }
        }

        private void OnCenterDragOver(object? sender, DragEventArgs e)
        {
            if (e.DataTransfer.Contains(SidebarView.DocumentItemFormat))
            {
                e.DragEffects = DragDropEffects.Copy;
                e.Handled = true;
            }
            else
            {
                e.DragEffects = DragDropEffects.None;
            }
        }

        private void OnCenterDrop(object? sender, DragEventArgs e)
        {
            if (BoundViewModel is null) return;

            var document = e.DataTransfer.TryGetValue(SidebarView.DocumentItemFormat);
            if (document != null)
            {
                BoundViewModel.Workspace.OpenDocument(document);
                e.Handled = true;
            }
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

        public static readonly DataFormat<DocumentTabViewModel> DocumentTabFormat = DataFormat.CreateInProcessFormat<DocumentTabViewModel>("DocumentTabViewModel");

        private PointerPressedEventArgs? _tabDragStartEventArgs;
        private bool _isTabDragging;

        private void OnTabPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var point = e.GetCurrentPoint(sender as Control);
            if (point.Properties.IsLeftButtonPressed)
            {
                _tabDragStartEventArgs = e;
                _isTabDragging = false;

                if (sender is Control { DataContext: DocumentTabViewModel tabViewModel })
                {
                    BoundViewModel?.Workspace.SetActiveTabCommand.Execute(tabViewModel);
                }
            }
        }

        private async void OnTabPointerMoved(object? sender, PointerEventArgs e)
        {
            if (e.GetCurrentPoint(sender as Control).Properties.IsLeftButtonPressed && !_isTabDragging && _tabDragStartEventArgs != null)
            {
                var currentPoint = e.GetCurrentPoint(sender as Control).Position;
                var startPoint = _tabDragStartEventArgs.GetCurrentPoint(sender as Control).Position;
                if (Math.Abs(currentPoint.X - startPoint.X) > 3 || Math.Abs(currentPoint.Y - startPoint.Y) > 3)
                {
                    _isTabDragging = true;
                    if (sender is Control { DataContext: DocumentTabViewModel tabViewModel })
                    {
                        var data = new DataTransfer();
                        data.Add(DataTransferItem.Create(DocumentTabFormat, tabViewModel));

                        tabViewModel.IsDragging = true;
                        ShowDragVisual(tabViewModel.Title, startPoint, false);

                        await DragDrop.DoDragDropAsync(_tabDragStartEventArgs, data, DragDropEffects.Move);

                        tabViewModel.IsDragging = false;
                        ClearDragVisual();
                    }
                }
            }
        }

        private void OnTabStripDragEnter(object? sender, DragEventArgs e)
        {
            if (e.DataTransfer.Contains(SidebarView.DocumentItemFormat) || e.DataTransfer.Contains(DocumentTabFormat))
            {
                TabStripScrollViewer.Background = new SolidColorBrush(Color.Parse("#1A2433"));
            }
        }

        private void OnTabStripDragLeave(object? sender, DragEventArgs e)
        {
            TabStripScrollViewer.Background = Brushes.Transparent;
            TabInsertionIndicator.IsVisible = false;
        }

        private void OnTabStripDragOver(object? sender, DragEventArgs e)
        {
            if (e.DataTransfer.Contains(SidebarView.DocumentItemFormat) || e.DataTransfer.Contains(DocumentTabFormat))
            {
                e.DragEffects = e.DataTransfer.Contains(SidebarView.DocumentItemFormat) ? DragDropEffects.Copy : DragDropEffects.Move;
                e.Handled = true;

                if (e.DataTransfer.Contains(DocumentTabFormat))
                {
                    var position = e.GetPosition(TabStripScrollViewer);
                    var newIndex = (int)((position.X + TabStripScrollViewer.Offset.X) / 212);
                    var maxIndex = BoundViewModel?.Workspace.OpenTabs.Count ?? 0;
                    if (newIndex > maxIndex) newIndex = maxIndex;

                    var caretX = newIndex * 212 - TabStripScrollViewer.Offset.X;
                    TabInsertionIndicator.Margin = new Thickness(caretX, 12, 0, 0);
                    TabInsertionIndicator.IsVisible = true;
                }
            }
            else
            {
                e.DragEffects = DragDropEffects.None;
            }
        }

        private void OnTabStripDrop(object? sender, DragEventArgs e)
        {
            TabStripScrollViewer.Background = Brushes.Transparent;
            TabInsertionIndicator.IsVisible = false;

            if (BoundViewModel is null)
            {
                return;
            }

            var document = e.DataTransfer.TryGetValue(SidebarView.DocumentItemFormat);
            if (document != null)
            {
                BoundViewModel.Workspace.OpenDocument(document);
                e.Handled = true;
                return;
            }

            var tab = e.DataTransfer.TryGetValue(DocumentTabFormat);
            if (tab != null)
            {
                var position = e.GetPosition(TabStripScrollViewer);
                var newIndex = (int)((position.X + TabStripScrollViewer.Offset.X) / 212);
                BoundViewModel.Workspace.MoveTab(tab, newIndex);
                e.Handled = true;
            }
        }
    }
}
