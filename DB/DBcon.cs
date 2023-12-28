using System;
using System.Data.SQLite;
using System.IO;

namespace BANKING.DB
{
    public class DatabaseConnection
    {
        public static string dbDir = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.FullName}\\DB";
        public static SQLiteConnection connection = new SQLiteConnection($"Data Source={dbDir}\\Bank.db;Version=3;");

    }
}
