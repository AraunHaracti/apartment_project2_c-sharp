using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Apartment.Views.WorkWithItem;

public partial class WorkWithItemWindow : Window
{
    public WorkWithItemWindow()
    {
        InitializeComponent();
#if DEBUG
        this.AttachDevTools();
#endif
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}