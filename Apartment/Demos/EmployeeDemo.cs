using System;
using Apartment.Utils;
using Apartment.ViewModels.UserInterfaces;
using Apartment.Views.UserInterfaces;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace Apartment.Demos;

public class EmployeeDemo : IModule
{
    private UserInterfaceView _view;
    private EmployeeViewModel _viewModel;
    
    public string Name => "Работники";
    public Bitmap Picture => new(AssetLoader.Open(new Uri("avares://Apartment/Assets/Categories/employee.png")));

    public UserControl UserInterface
    {
        get
        {
            if (_view == null)
                CreateDemo();
            return _view;
        }
    }
    
    private void CreateDemo()
    {
        _view = new();
        _viewModel = new();
        _view.DataContext = _viewModel;
    }
    public void Deactivate()
    {
        _viewModel.Dispose();
        _view = null;
    }
}