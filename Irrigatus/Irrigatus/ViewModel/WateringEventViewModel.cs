using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;

namespace Irrigatus.ViewModel
{
    class WateringEventViewModel
    {
        public string guid { get; set; }
        public int stationGUID { get; set; }
        public int wateringTime { get; set; }
        public string startTime { get; set; }
        public string wateringDays { get; set; }

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
                this.stationGUID = checkExistingEvent.stationGUID;
                this.wateringTime = checkExistingEvent.wateringTime;
                this.startTime = checkExistingEvent.startTime;
                this.wateringDays = checkExistingEvent.wateringDays;
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
                    this.stationGUID = result.stationGUID;
                    this.wateringTime = result.wateringTime;
                    this.wateringDays = result.wateringDays;
                    this.startTime = result.startTime;
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
            wateringEvent.stationGUID = this.stationGUID;
            wateringEvent.startTime = this.startTime;
            wateringEvent.wateringTime = this.wateringTime;
            wateringEvent.wateringDays = this.wateringDays;
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
