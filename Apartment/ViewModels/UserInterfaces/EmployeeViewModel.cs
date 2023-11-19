using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Apartment.Models;
using Apartment.Utils;
using Apartment.ViewModels.WorkWithItem;
using Apartment.Views.UserInterfaces.DataGrids;
using Apartment.Views.WorkWithItem;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data;
using MySqlConnector;
using ReactiveUI;

namespace Apartment.ViewModels.UserInterfaces;

public class EmployeeViewModel : UserInterfaceViewModel<Employee>
{
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

    protected override string GetSql()
    {
        return "select * from employee";
    }

    protected override string GetNameCategory()
    {
        return "Работники";
    }

    protected override UserControl GetDataTable()
    {
        return new EmployeeDataGrid();
    }

    protected override void AddItem(Window window, Action action)
    {
        var view = new WorkWithItemWindow() { DataContext = new EmployeeWorkWithItem(action) };
        view.ShowDialog(window);
    }

    protected override void EditItem(Window window, Action action, Employee item)
    {
        var view = new WorkWithItemWindow() { DataContext = new EmployeeWorkWithItem(action, item) };
        view.ShowDialog(window);
    }

    protected override void DeleteItem(Action action, Employee item)
    {
        using (Database db = new Database())
        {
            db.SetData($"delete from employee where employee.id = {item.Id}");
        }
    }
}