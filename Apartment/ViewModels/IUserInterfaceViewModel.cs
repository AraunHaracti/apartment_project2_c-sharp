using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Apartment.Utils;
using Avalonia.Controls;

namespace Apartment.ViewModels;

public interface IUserInterfaceViewModel : IDisposable
{
    object? DataGridContainer { get; }
    int CurrentPage { get; set; }
    int TotalPages { get; }
    string SearchQuery { get; set; }
    void AddItemButton();
    void EditItemButton();
    void DeleteItemButton();
    void TakeItems(TakeItemsEnum takeItemsEnum);
}