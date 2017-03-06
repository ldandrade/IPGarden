using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using IPGarden.Model;

namespace IPGarden.Database
{
    public class IPGardenDatabase
    {
        readonly SQLiteAsyncConnection database;

        public IPGardenDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<SensorMeasure>().Wait();
            database.CreateTableAsync<WateringEvent>().Wait();
            database.CreateTableAsync<WateringStation>().Wait();
        }

        public Task<List<WateringStation>> GetWateringStationsAsync()
        {
            return database.Table<WateringStation>().ToListAsync();
        }

        public Task<WateringStation> GetWateringStationAsync(string guid)
        {
            return database.Table<WateringStation>().Where(i => i.guid == guid).FirstOrDefaultAsync();
        }

        public Task<int> SaveWateringStationAsync(WateringStation wateringStation)
        {
            if (wateringStation.guid != string.Empty)
            {
                return database.UpdateAsync(wateringStation);
            }
            else
            {
                return database.InsertAsync(wateringStation);
            }
        }
    }
}
