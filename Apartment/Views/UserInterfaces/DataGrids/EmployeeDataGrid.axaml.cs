using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Apartment.Views.UserInterfaces.DataGrids;

public partial class EmployeeDataGrid : UserControl
{
    public EmployeeDataGrid()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}