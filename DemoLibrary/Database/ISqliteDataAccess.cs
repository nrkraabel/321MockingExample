using System.Collections.Generic;

namespace DemoLibrary.Database
{
    public interface ISqliteDataAccess
    {
        List<T> LoadData<T>(string sql);
        void SaveData<T>(T person, string sql);
        void UpdateData<T>(T person, string sql);
    }
}