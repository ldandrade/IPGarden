using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using Irrigatus.Model;

namespace Irrigatus.Database
{
    public class IrrigatusDatabase
    {
        SQLiteAsyncConnection database;

        public IrrigatusDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<WateringEvent>().Wait();
            database.CreateTableAsync<WateringStation>().Wait();
            database.CreateTableAsync<SensorMeasure>().Wait();
        }

        // ---------------------------------- WATERING STATION OPERATIONS -------------------------------
        public Task<List<WateringStation>> GetWateringStationsAsync()
        {
            return database.QueryAsync<WateringStation>("select * from WateringStation order by fullName");
        }

        public Task<WateringStation> GetWateringStationAsync(string guid)
        {
            return database.Table<WateringStation>().Where(i => i.guid == guid).FirstOrDefaultAsync();
        }

        public Task<WateringStation> GetWateringStationAsync(int number)
        {
            return database.Table<WateringStation>().Where(i => i.number == number).FirstOrDefaultAsync();
        }

        public async Task<int> SaveWateringStationAsync(WateringStation wateringStation)
        {
            WateringStation existingStation = await database.Table<WateringStation>().Where(i => i.guid == wateringStation.guid).FirstOrDefaultAsync();
            if (existingStation != null)
            {
                return database.UpdateAsync(wateringStation).Result;
            }
            else
            {
                return database.InsertAsync(wateringStation).Result;
            }
        }

        public async Task<int> DeleteWateringStationAsync(WateringStation wateringStation)
        {
            int result = 0;
            WateringStation existingStation = await database.Table<WateringStation>().Where(i => i.guid == wateringStation.guid).FirstOrDefaultAsync();
            if (existingStation != null)
            {
                result = database.DeleteAsync(wateringStation).Result;
            }
            return result;
        }

        // ---------------------------------- WATERING EVENT OPERATIONS -------------------------------
        public Task<List<WateringEvent>> GetWateringEventsAsync()
        {
            return database.QueryAsync<WateringEvent>("select * from WateringEvent order by startTime");
        }

        public Task<WateringEvent> GetWateringEventAsync(string guid)
        {
            return database.Table<WateringEvent>().Where(i => i.guid == guid).FirstOrDefaultAsync();
        }

        public async Task<int> SaveWateringEventAsync(WateringEvent wateringEvent)
        {
            WateringEvent existingEvent = await database.Table<WateringEvent>().Where(i => i.guid == wateringEvent.guid).FirstOrDefaultAsync();
            if (existingEvent != null)
            {
                return database.UpdateAsync(wateringEvent).Result;
            }
            else
            {
                return database.InsertAsync(wateringEvent).Result;
            }
        }

        public async Task<int> DeleteWateringEventAsync(WateringEvent wateringEvent)
        {
            int result = 0;
            WateringEvent existingEvent = await database.Table<WateringEvent>().Where(i => i.guid == wateringEvent.guid).FirstOrDefaultAsync();
            if (existingEvent != null)
            {
                result = database.DeleteAsync(existingEvent).Result;
            }
            return result;
        }
    }
}
