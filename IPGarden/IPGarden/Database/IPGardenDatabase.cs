using SQLite;

namespace IPGarden.Database
{
    public class IPGardenDatabase
    {
        readonly SQLiteAsyncConnection database;

        public IPGardenDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            //database.CreateTableAsync<TodoItem>().Wait();
        }
    }
}
