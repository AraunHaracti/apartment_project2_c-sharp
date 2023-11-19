using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Apartment.Models;
using Apartment.Utils;
using Avalonia;
using Avalonia.Collections;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using MySqlConnector;
using ReactiveUI;

namespace Apartment.ViewModels.UserInterfaces;

public abstract class UserInterfaceViewModel<T> : ViewModelBase, IUserInterfaceViewModel 
{
    public string NameCategory { get => GetNameCategory(); }
    
    private readonly Window? _parentWindow;
    
    private List<T> _itemsFromDatabase;

    private List<T> _itemsFilter;

    private string _sql;
    
    private readonly int _countItems = 15;

    public UserControl DataTable { get => new Views.UserInterfaces.DataGrids.EmployeeDataGrid(); }
    
    public int CurrentPage { get; set; } = 1;

    public int TotalPages
    {
        get
        {
            int page = (int)Math.Ceiling(_itemsFilter.Count / (double) _countItems);
            return page == 0 ? 1 : page;
        }
    }

    public T CurrentItem { get; set; }

    private ObservableCollection<T> _itemsOnDataGrid;
    
    public ObservableCollection<T> ItemsOnDataGrid
    {
        get => _itemsOnDataGrid;
        set
        {
            _itemsOnDataGrid = value;
            this.RaisePropertyChanged();
        }
    }

    private string _searchQuery = "";
    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            _searchQuery = value;
            this.RaisePropertyChanged();
        }
    }
    
    public UserInterfaceViewModel()
    {
        _sql = GetSql();
        if (Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            _parentWindow = desktop.MainWindow;
        }
        
        GetAndUpdateItems();
        
        PropertyChanged += OnSearchQueryChanged;
    }
    
    public void AddItemButton()
    {
        // var view = new CourseInfoCard();
        // var vm = new CourseInfoCardViewModel(GetAndUpdateItems);
        // view.DataContext = vm;
        // view.ShowDialog(_parentWindow);
    }

    public void EditItemButton()
    {
        if (CurrentItem == null)
            return;
        // var view = new CourseInfoCard();
        // var vm = new CourseInfoCardViewModel(GetAndUpdateItems, CurrentItem);
        // view.DataContext = vm;
        // view.ShowDialog(_parentWindow);
    }
    
    public void DeleteItemButton()
    {
        // if (CurrentItem == null)
        //     return;
        // var view = new CourseInfoCard();
        // var vm = new CourseInfoCardViewModel(GetAndUpdateItems, CurrentItem);
        // view.DataContext = vm;
        // view.ShowDialog(_parentWindow);
    }
    
    private void OnSearchQueryChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(SearchQuery)) 
            return;

        UpdateItems();
    }

    private void GetAndUpdateItems()
    {
        GetDataFromDatabase();
        UpdateItems();
    }

    private void UpdateItems()
    {
        Search();
        this.RaisePropertyChanged(nameof(TotalPages));
        TakeItems(TakeItemsEnum.FirstItems);
        this.RaisePropertyChanged(nameof(CurrentPage));
    }
    
    private void Search()
    {
        if (SearchQuery == "")
        {
            _itemsFilter = new(_itemsFromDatabase);
            return;
        }

        _itemsFilter = new(_itemsFromDatabase.Where(SetFilterForSearch()));
    }
    
    private void GetDataFromDatabase()
    {
        _itemsFromDatabase = new List<T>();

        using Database db = new Database();
        
        MySqlDataReader reader = db.GetData(_sql);
            
        while (reader.Read() && reader.HasRows)
        {
            _itemsFromDatabase.Add(GetItemFromReader(reader));
        }
    }
    
    public void TakeItems(TakeItemsEnum takeItems)
    {
        switch (takeItems)
        {
            default:
            case TakeItemsEnum.FirstItems:
                CurrentPage = 1;
                break;
            case TakeItemsEnum.LastItems:
                CurrentPage = TotalPages;
                break;
            case TakeItemsEnum.NextItems:
                if (CurrentPage < TotalPages)
                    CurrentPage += 1;
                break;
            case TakeItemsEnum.PreviousItems:
                if (CurrentPage > 1)
                    CurrentPage -= 1;
                break;
        }

        ItemsOnDataGrid = new ObservableCollection<T>(_itemsFilter.Skip((CurrentPage - 1) * _countItems).Take(_countItems));
    }
    
    public void Dispose() { }
    
    
    protected abstract T GetItemFromReader(MySqlDataReader reader);
    protected abstract Func<T, bool> SetFilterForSearch();
    protected abstract string GetSql();
    protected abstract string GetNameCategory();
}