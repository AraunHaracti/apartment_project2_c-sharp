using System.Collections.Generic;
using MySqlConnector;

namespace Apartment.Utils;

public static class Settings
{
    public static List<IModule> ModulesMainWindow = new List<IModule>()
    {
        
    };
    
    public static MySqlConnectionStringBuilder DatabaseConnectionStringBuilder = new()
    {
        Server = "10.10.1.24",
        Port = 3306,
        Database = "pro1_12",
        UserID = "user_01",
        Password = "user01pro"
    };
}