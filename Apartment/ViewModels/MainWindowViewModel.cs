using System.Collections.Generic;
using System.ComponentModel;
using Apartment.Utils;
using Avalonia.Controls;

namespace Apartment.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged = delegate { };
    
    public List<IModule> Modules { get; private set; }
    
    private IModule _selectedModule;
    public IModule SelectedModule
    {
        get => _selectedModule;
        set
        {
            if (value == _selectedModule) return;
            if (_selectedModule != null) _selectedModule.Deactivate();
            _selectedModule = value;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedModule)));
            PropertyChanged(this, new PropertyChangedEventArgs("UserInterface"));
        }
    }
    
    public MainWindowViewModel(){}
    
    
    public MainWindowViewModel(IEnumerable<IModule> modules)
    {
        Modules = new List<IModule>(modules);
        
        if (this.Modules.Count > 0)
        {
            SelectedModule = this.Modules[0];
        }
    }
    
    public UserControl UserInterface
    {
        get
        {
            if (SelectedModule == null) 
                return null;
            return SelectedModule.UserInterface;
        }
    }
}