using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;

namespace Irrigatus.ViewModel
{
    public static class AllWateringEventViewModel
    {
        private static ObservableCollection<WateringEventViewModel> wateringEventsViewModel;
        private static List<WateringEvent> wateringEvents;

        public static async Task<ObservableCollection<WateringEventViewModel>> RetrieveWateringEventsAsync()
        {
            wateringEvents = await App.Database.GetWateringEventsAsync();
            wateringEventsViewModel = new ObservableCollection<WateringEventViewModel>();
            WateringEventViewModel eventViewModel = new WateringEventViewModel();
            foreach (WateringEvent wateringEvent in wateringEvents)
            {
                eventViewModel = new WateringEventViewModel();
                eventViewModel.guid = wateringEvent.guid;
                eventViewModel.stationFullName = wateringEvent.stationFullName;
                eventViewModel.wateringTime = wateringEvent.wateringTime;
                eventViewModel.startTime = wateringEvent.startTime;
                eventViewModel.sunday = wateringEvent.sunday;
                eventViewModel.monday = wateringEvent.monday;
                eventViewModel.tuesday = wateringEvent.tuesday;
                eventViewModel.wednesday = wateringEvent.wednesday;
                eventViewModel.thursday = wateringEvent.thursday;
                eventViewModel.friday = wateringEvent.friday;
                eventViewModel.saturday = wateringEvent.saturday;
                wateringEventsViewModel.Add(eventViewModel);
            }
            return wateringEventsViewModel;
        }
    }
}
