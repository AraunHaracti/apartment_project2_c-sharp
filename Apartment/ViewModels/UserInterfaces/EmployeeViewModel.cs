using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Apartment.Models;
using Apartment.Utils;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using MySqlConnector;
using ReactiveUI;

namespace Apartment.ViewModels.UserInterfaces;

public class EmployeeViewModel : UserInterfaceViewModel<Employee>
{
    protected override object? GetDataGrid()
    {
        return new DataGrid()
            {
                AutoGenerateColumns = false,
                CanUserSortColumns = false,
                CanUserResizeColumns = false,
                MinColumnWidth = 100,
                IsReadOnly = true,
                ItemsSource = ItemsOnDataGrid,
                SelectedItem = CurrentItem,
                Height = 600,
                Columns = { 
                    new DataGridTextColumn {Header = "Имя", Width = new DataGridLength(250), Binding = new Binding("UserInterfaceViewModel<T>.Name")}, 
                    new DataGridTextColumn {Header = "Фамилия", Width = new DataGridLength(250), Binding = new Binding("UserInterfaceViewModel<T>.Surname")}, 
                    new DataGridTextColumn {Header = "День рождения", Width = new DataGridLength(150), Binding = new Binding("UserInterfaceViewModel<T>.Birthday", BindingMode.TwoWay)},
                    new DataGridTextColumn {Header = "Почта", Width = new DataGridLength(200), Binding = new Binding("UserInterfaceViewModel<T>.Email")}}
            };
    }

    protected override Employee GetItemFromReader(MySqlDataReader reader)
    {
        var currentItem = new Employee()
        {
            Id = reader.GetInt32("id"),
            Name = reader.GetString("name"),
            Surname = reader.GetString("surname"),
            Birthday = reader.GetDateTimeOffset("birthday"),
            Email = reader.GetString("email"),
        };
        
        return currentItem;
    }

    protected override Func<Employee, bool> SetFilterForSearch()
    {
        return it =>
            it.Name.ToLower().Contains(SearchQuery.ToLower()) ||
            it.Surname.ToLower().Contains(SearchQuery.ToLower()) ||
            it.Birthday.ToString("yyyy-MM-dd").ToLower().Contains(SearchQuery.ToLower()) ||
            it.Email.ToLower().Contains(SearchQuery.ToLower());
    }

    protected override ObservableCollection<DataGridColumn> GetColumns()
    {
        ObservableCollection<DataGridColumn> columns = new ObservableCollection<DataGridColumn>();
        columns.Add(new DataGridTextColumn {Header = "Имя", Width = new DataGridLength(250), Binding = new Binding("UserInterfaceViewModel<T>.Name")});
        columns.Add(new DataGridTextColumn {Header = "Фамилия", Width = new DataGridLength(250), Binding = new Binding("UserInterfaceViewModel<T>.Surname")});
        columns.Add(new DataGridTextColumn {Header = "День рождения", Width = new DataGridLength(150), Binding = new Binding("UserInterfaceViewModel<T>.Birthday", BindingMode.TwoWay)});
        columns.Add(new DataGridTextColumn {Header = "Почта", Width = new DataGridLength(200), Binding = new Binding("UserInterfaceViewModel<T>.Email")});
        return columns;
    }

    protected override string GetSql()
    {
        return "select * from employee";
    }
}