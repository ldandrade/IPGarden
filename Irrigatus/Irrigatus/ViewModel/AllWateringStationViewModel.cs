using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;
using System.Collections.ObjectModel;

namespace Irrigatus.ViewModel
{
    public static class AllWateringStationViewModel
    {
        private static ObservableCollection<WateringStationViewModel> wateringStationsViewModel;
        private static List<WateringStation> wateringStations;

        public static async Task<ObservableCollection<WateringStationViewModel>> RetrieveWateringStationsAsync()
        {
            wateringStations = await App.Database.GetWateringStationsAsync();
            wateringStationsViewModel = new ObservableCollection<WateringStationViewModel>();
            WateringStationViewModel stationViewModel = new WateringStationViewModel();
            foreach (WateringStation station in wateringStations)
            {
                stationViewModel = new WateringStationViewModel();
                stationViewModel.guid = station.guid;
                stationViewModel.number = station.number;
                stationViewModel.name = station.name;
                stationViewModel.wateringTime = station.wateringTime;
                stationViewModel.fullName = station.fullName;
                stationViewModel.active = station.active;
                wateringStationsViewModel.Add(stationViewModel);
            }
            return wateringStationsViewModel;
        }

    }
}
