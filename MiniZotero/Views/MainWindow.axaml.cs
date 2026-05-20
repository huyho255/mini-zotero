using Avalonia.Controls;
using MiniZotero.ViewModels;

namespace MiniZotero.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}