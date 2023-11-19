using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Apartment.Views.UserInterfaces.DataGrids;

public partial class ProblemDataGrid : UserControl
{
    public ProblemDataGrid()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}