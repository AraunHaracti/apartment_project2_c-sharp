using System.Collections.Generic;
using Apartment.Utils;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Apartment.ViewModels;
using Apartment.Views;

namespace Apartment;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            IEnumerable<IModule> modules = Settings.ModulesMainWindow;
            var vm = new MainWindowViewModel(modules);
            desktop.MainWindow = new MainWindow
            {
                DataContext = vm,
            };

            desktop.MainWindow.Closing += (s, args) => vm.SelectedModule.Deactivate();
        }

        base.OnFrameworkInitializationCompleted();
    }
}