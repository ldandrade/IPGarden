using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;

namespace Irrigatus.ViewModel
{
    public class WateringStationViewModel
    {
        public string guid { get; set; }
        public int number { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public int wateringTime { get; set; }
        public string fullName { get; set; }

        public WateringStationViewModel()
        {
            this.guid = Guid.NewGuid().ToString();
            this.active = false;
        }

        public async Task<bool> SaveWateringStation()
        {
            int result = 0;
            WateringStation wateringStation = new WateringStation();
            wateringStation.guid = this.guid;
            wateringStation.number = this.number;
            wateringStation.name = this.name;
            wateringStation.wateringTime = this.wateringTime;
            this.fullName = String.Concat(this.number, " - ", this.name);
            wateringStation.fullName = String.Concat(this.number, " - ", this.name);
            try
            {
                result = await App.Database.SaveWateringStationAsync(wateringStation);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
