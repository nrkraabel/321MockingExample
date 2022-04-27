using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace DemoLibrary.Database
{
    public class SqliteDataAccess : ISqliteDataAccess
    {
        public List<T> LoadData<T>(string sql)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<T> output = connection.Query<T>(sql, new DynamicParameters());
                return output.ToList();
            }
        }

        public void SaveData<T>(T person, string sql)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute(sql, person);
            }
        }

        public void UpdateData<T>(T person, string sql)
        {
            using (IDbConnection connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Execute(sql, person);
            }
        }

        private string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
