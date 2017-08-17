using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;
using System.Collections.ObjectModel;

namespace Irrigatus.ViewModel
{
    public class AllWateringStationViewModel
    {
        private ObservableCollection<WateringStationViewModel> wateringStationsList;
        private List<WateringStation> wateringStations;

        public async Task<ObservableCollection<WateringStationViewModel>> RetrieveWateringStationsFromDBAsync()
        {
            wateringStations = await App.Database.GetWateringStationsAsync();
            wateringStationsList = new ObservableCollection<WateringStationViewModel>();
            WateringStationViewModel stationViewModel = new WateringStationViewModel();
            foreach (WateringStation station in wateringStations)
            {
                stationViewModel = new WateringStationViewModel();
                stationViewModel.GUID = station.guid;
                stationViewModel.Number = station.number;
                stationViewModel.Name = station.name;
                stationViewModel.WateringTime = station.wateringTime;
                stationViewModel.FullName = station.fullName;
                stationViewModel.Active = station.active;
                wateringStationsList.Add(stationViewModel);
            }
            return wateringStationsList;
        }

        public async Task UpdateWateringStationRelayStatusAsync()
        {
            try
            {
                foreach (WateringStationViewModel wsvm in wateringStationsList)
                    wsvm.Active = await App.restService.GetSwitchStateAsync(wsvm.Number.ToString());
            }
            catch (InvalidOperationException ex)
            {
                throw ex;
            }
        }

        public ObservableCollection<WateringStationViewModel> WateringStationsList
        {
            set
            {
                wateringStationsList = value;
            }
            get
            {
                return wateringStationsList;
            }
        }
    }
}
