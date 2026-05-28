using CommunityToolkit.Mvvm.ComponentModel;

namespace MiniZotero.ViewModels
{
    public partial class TableCellViewModel : ObservableObject
    {
        public int Row { get; }
        public int Column { get; }

        [ObservableProperty]
        private bool _isSelected;

        public TableCellViewModel(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
