using System.Drawing;
using Avalonia.Controls;

namespace Apartment.Utils;

public interface IModule
{ 
    string Name { get; }
    
    UserControl UserInterface { get; }

    Bitmap Picture { get; }
    
    void Deactivate();
}