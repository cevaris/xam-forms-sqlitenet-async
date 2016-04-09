using SQLite.Net.Async;
using SQLite.Net;

namespace SqliteAsyncExample
{
    /// <summary>
    /// SQLite.Net-PCL
    /// 
    /// https://github.com/oysteinkrog/SQLite.Net-PCL
    /// http://www.xamarinhelp.com/local-storage-day-10/
    /// </summary>
    public interface ISQLite
    {
        void CloseConnection();
        SQLiteConnection GetConnection();
        SQLiteAsyncConnection GetAsyncConnection();
        void DeleteDatabase();
    }
}

