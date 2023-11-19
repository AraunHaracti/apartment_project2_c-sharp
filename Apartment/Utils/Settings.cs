using System.Collections.Generic;
using Apartment.Demos;
using MySqlConnector;

namespace Apartment.Utils;

public static class Settings
{
    public static List<IModule> ModulesMainWindow = new()
    {
        new EmployeeDemo(), new ProblemDemo()
    };
    
    public static MySqlConnectionStringBuilder DatabaseConnectionStringBuilder = new()
    {
        Server = "localhost",
        Port = 3306,
        Database = "project2",
        UserID = "root",
        Password = "password"
    };
}