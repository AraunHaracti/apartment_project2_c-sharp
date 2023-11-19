using System;
using System.Data;
using Apartment.Models;
using Apartment.Utils;
using Apartment.ViewModels.WorkWithItem;
using Apartment.Views.UserInterfaces.DataGrids;
using Apartment.Views.WorkWithItem;
using Avalonia.Controls;
using MySqlConnector;

namespace Apartment.ViewModels.UserInterfaces;

public class ProblemViewModel : UserInterfaceViewModel<Problem>
{
    protected override Problem GetItemFromReader(MySqlDataReader reader)
    {
        var currentItem = new Problem()
        {
            Id = reader.GetInt32("id"),
            Place = reader.GetString("place"),
            DateAdded = reader.GetDateTime("date_added"),
            DateCompleted = reader.GetDateTime("date_completed"),
            Description = reader.GetString("description"),
            ProblemPriority = reader.GetString("problem_priority"),
            ProblemStatus = reader.GetString("problem_status"),
        };
        
        return currentItem;
    }

    protected override Func<Problem, bool> SetFilterForSearch()
    {
        return it =>
            it.Place.ToLower().Contains(SearchQuery.ToLower()) ||
            it.DateAdded.ToString("yyyy-MM-dd").ToLower().Contains(SearchQuery.ToLower()) ||
            it.Description.ToString().Contains(SearchQuery.ToLower());
    }

    protected override string GetSql()
    {
        return "select * from problem where date_complited != 'done'";
    }

    protected override string GetNameCategory()
    {
        return "Проблемы";
    }

    protected override UserControl GetDataTable()
    {
        return new ProblemDataGrid();
    }

    protected override void AddItem(Window window, Action action)
    {
        var view = new WorkWithItemWindow() { DataContext = new ProblemWorkWithItem(action) };
        view.ShowDialog(window);
    }

    protected override void EditItem(Window window, Action action, Problem item)
    {
        var view = new WorkWithItemWindow() { DataContext = new ProblemWorkWithItem(action, item) };
        view.ShowDialog(window);
    }

    protected override void DeleteItem(Action action, Problem item)
    {
        using (Database db = new Database())
        {
            db.SetData($"delete from problem where problem.id = {item.Id}");
        }
        action.Invoke();
    }
}