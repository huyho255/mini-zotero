using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace MiniZotero.Views
{
    public partial class SidebarView : UserControl
    {
        public static readonly DataFormat<Models.DocumentItem> DocumentItemFormat = DataFormat.CreateInProcessFormat<Models.DocumentItem>("DocumentItem");

        private PointerPressedEventArgs? _dragStartEventArgs;
        private bool _isDragging;

        public SidebarView()
        {
            InitializeComponent();
        }

        private void OnDocumentDoubleTapped(object? sender, TappedEventArgs e)
        {
            if (sender is Control { DataContext: ViewModels.DocumentExplorerItem { IsDocument: true } item } &&
                DataContext is ViewModels.SidebarViewModel vm)
            {
                vm.RequestOpenDocumentCommand.Execute(item.Document);
            }
        }

        private void OnDocumentPointerPressed(object? sender, PointerPressedEventArgs e)
        {
            var point = e.GetCurrentPoint(sender as Control);
            if (point.Properties.IsLeftButtonPressed)
            {
                _dragStartEventArgs = e;
                _isDragging = false;
            }
        }

        private async void OnDocumentPointerMoved(object? sender, PointerEventArgs e)
        {
            if (e.GetCurrentPoint(sender as Control).Properties.IsLeftButtonPressed && !_isDragging && _dragStartEventArgs != null)
            {
                var currentPoint = e.GetCurrentPoint(sender as Control).Position;
                var startPoint = _dragStartEventArgs.GetCurrentPoint(sender as Control).Position;
                if (Math.Abs(currentPoint.X - startPoint.X) > 3 || Math.Abs(currentPoint.Y - startPoint.Y) > 3)
                {
                    _isDragging = true;
                    if (sender is Control { DataContext: ViewModels.DocumentExplorerItem { IsDocument: true } item })
                    {
                        var data = new DataTransfer();
                        data.Add(DataTransferItem.Create(DocumentItemFormat, item.Document));

                        if (TopLevel.GetTopLevel(this) is MainWindow mainWindow)
                        {
                            mainWindow.ShowDragVisual(item.Document.Title, startPoint, true);
                        }

                        await DragDrop.DoDragDropAsync(_dragStartEventArgs, data, DragDropEffects.Copy | DragDropEffects.Move);

                        if (TopLevel.GetTopLevel(this) is MainWindow mw)
                        {
                            mw.ClearDragVisual();
                        }
                    }
                }
            }
        }
    }
}
