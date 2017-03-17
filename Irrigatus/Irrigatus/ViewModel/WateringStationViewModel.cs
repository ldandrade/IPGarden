using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;
using System.ComponentModel;

namespace Irrigatus.ViewModel
{
    public class WateringStationViewModel : INotifyPropertyChanged
    {
        private string guid;
        private int number;
        private string name;
        private bool active;
        private int wateringTime;
        private string fullName;

        public WateringStationViewModel()
        {
            this.guid = Guid.NewGuid().ToString();
            this.active = false;
        }

        public WateringStationViewModel(int stationNumber)
        {
            WateringStation checkExistingStation = App.Database.GetWateringStationAsync(stationNumber).Result;
            if (checkExistingStation == null)
            {
                this.guid = Guid.NewGuid().ToString();
                this.active = false;
            }
            else
            {
                this.guid = checkExistingStation.guid;
                this.number = checkExistingStation.number;
                this.name = checkExistingStation.name;
                this.fullName = checkExistingStation.fullName;
                this.active = checkExistingStation.active;
                this.wateringTime = checkExistingStation.wateringTime;
            }
        }

        // ######################### gETTER AND SETTER OPERATIONS ##############################

        public event PropertyChangedEventHandler PropertyChanged;

        public string GUID
        {
            set
            {
                if (guid != value)
                {
                    guid = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("GUID"));
                    }
                }
            }
            get
            {
                return guid;
            }
        }

        public int Number
        {
            set
            {
                if (number != value)
                {
                    number = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Number"));
                    }
                }
            }
            get
            {
                return number;
            }
        }

        public string Name
        {
            set
            {
                if (name != value)
                {
                    name = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Name"));
                    }
                }
            }
            get
            {
                return name;
            }
        }

        public bool Active
        {
            set
            {
                if (active != value)
                {
                    active = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("Active"));
                    }
                }
            }
            get
            {
                return active;
            }
        }

        public int WateringTime
        {
            set
            {
                if (wateringTime != value)
                {
                    wateringTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("WateringTime"));
                    }
                }
            }
            get
            {
                return wateringTime;
            }
        }

        public string FullName
        {
            set
            {
                if (fullName != value)
                {
                    fullName = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this,
                            new PropertyChangedEventArgs("FullName"));
                    }
                }
            }
            get
            {
                return fullName;
            }
        }

        // ######################### MODEL OPERATIONS ##############################

        public async Task<bool> RetrieveWateringStation(int stationNumber)
        {
            WateringStation result = new WateringStation();
            try
            {
                result = await App.Database.GetWateringStationAsync(stationNumber);
                if (result != null)
                {
                    this.fullName = result.fullName;
                    this.guid = result.guid;
                    this.name = result.name;
                    this.number = result.number;
                    this.wateringTime = result.wateringTime;
                }
            }
            catch
            {
                return false;
            }
            return true;
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

        public async Task<bool> DeleteWateringStation()
        {
            int result = 0;
            WateringStation wateringStation = new WateringStation();
            wateringStation.guid = this.guid;
            wateringStation.number = this.number;
            try
            {
                result = await App.Database.DeleteWateringStationAsync(wateringStation);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
