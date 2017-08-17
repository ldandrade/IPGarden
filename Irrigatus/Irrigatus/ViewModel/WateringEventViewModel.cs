using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;

namespace Irrigatus.ViewModel
{
    public class WateringEventViewModel
    {
        public string guid { get; set; }
        public string stationFullName { get; set; }
        public int wateringTime { get; set; }
        public string startTime { get; set; }
        public bool sunday { get; set; }
        public bool monday { get; set; }
        public bool tuesday { get; set; }
        public bool wednesday { get; set; }
        public bool thursday { get; set; }
        public bool friday { get; set; }
        public bool saturday { get; set; }

        public WateringEventViewModel()
        {
            this.guid = Guid.NewGuid().ToString();
        }

        public WateringEventViewModel(string guid)
        {
            WateringEvent checkExistingEvent = App.Database.GetWateringEventAsync(guid).Result;
            if (checkExistingEvent == null)
            {
                this.guid = Guid.NewGuid().ToString();
            }
            else
            {
                this.guid = checkExistingEvent.guid;
                this.stationFullName = checkExistingEvent.stationFullName;
                this.wateringTime = checkExistingEvent.wateringTime;
                this.startTime = checkExistingEvent.startTime;
                this.sunday = checkExistingEvent.sunday;
                this.monday = checkExistingEvent.monday;
                this.tuesday = checkExistingEvent.tuesday;
                this.wednesday = checkExistingEvent.wednesday;
                this.thursday = checkExistingEvent.thursday;
                this.friday = checkExistingEvent.friday;
                this.saturday = checkExistingEvent.saturday;
            }
        }

        public async Task<bool> RetrieveWateringEvent(string guid)
        {
            WateringEvent result = new WateringEvent();
            try
            {
                result = await App.Database.GetWateringEventAsync(guid);
                if (result != null)
                {
                    this.guid = result.guid;
                    this.stationFullName = result.stationFullName;
                    this.wateringTime = result.wateringTime;
                    this.startTime = result.startTime;
                    this.sunday = result.sunday;
                    this.monday = result.monday;
                    this.tuesday = result.tuesday;
                    this.wednesday = result.wednesday;
                    this.thursday = result.thursday;
                    this.friday = result.friday;
                    this.saturday = result.saturday;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveWateringEvent()
        {
            int result = 0;
            WateringEvent wateringEvent = new WateringEvent();
            wateringEvent.guid = this.guid;
            wateringEvent.stationFullName = this.stationFullName;
            wateringEvent.startTime = this.startTime;
            wateringEvent.wateringTime = this.wateringTime;
            wateringEvent.sunday = this.sunday;
            wateringEvent.monday = this.monday;
            wateringEvent.tuesday = this.tuesday;
            wateringEvent.wednesday = this.wednesday;
            wateringEvent.thursday = this.thursday;
            wateringEvent.friday = this.friday;
            wateringEvent.saturday = this.saturday;
            try
            {
                result = await App.Database.SaveWateringEventAsync(wateringEvent);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public async Task<bool> DeleteWateringEvent()
        {
            int result = 0;
            WateringEvent wateringEvent = new WateringEvent();
            wateringEvent.guid = this.guid;
            try
            {
                result = await App.Database.DeleteWateringEventAsync(wateringEvent);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
