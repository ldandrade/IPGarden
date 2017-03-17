using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace Irrigatus.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditWateringEventPage : ContentPage
    {
        WateringEventViewModel wateringEventViewModel;
        AllWateringStationViewModel wateringStationsViewModel;

        public AddEditWateringEventPage()
        {
            InitializeComponent();
            wateringStationsViewModel = new AllWateringStationViewModel();
        }

        public AddEditWateringEventPage(WateringEventViewModel eventViewModel)
        {
            InitializeComponent();
            wateringStationsViewModel = new AllWateringStationViewModel();
            wateringEventViewModel = eventViewModel;
            stepperWateringTimeValue.Text = eventViewModel.wateringTime.ToString();
            //tpickerStartTime.Time = new TimeSpan(eventViewModel.startTime;
            switchSunday.On = eventViewModel.sunday;
            switchMonday.On = eventViewModel.monday;
            switchTuesday.On = eventViewModel.tuesday;
            switchWednesday.On = eventViewModel.wednesday;
            switchThursday.On = eventViewModel.thursday;
            switchFriday.On = eventViewModel.friday;
            switchSaturday.On = eventViewModel.saturday;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ObservableCollection<WateringStationViewModel> pickerList = await wateringStationsViewModel.RetrieveWateringStationsFromDBAsync();
            foreach (WateringStationViewModel station in pickerList)
            {
                pickerRelayPanelStationNumber.Items.Add(station.FullName);
            }
            if (wateringEventViewModel != null)
                pickerRelayPanelStationNumber.SelectedIndex = pickerRelayPanelStationNumber.Items.IndexOf(wateringEventViewModel.stationFullName);
        }

    private async void OkButtonClicked(object sender, EventArgs e)
        {
            wateringEventViewModel = new WateringEventViewModel();
            WateringStationViewModel wateringStationViewModel = new WateringStationViewModel();
            string wateringStationFullName = pickerRelayPanelStationNumber.Items[pickerRelayPanelStationNumber.SelectedIndex];
            bool existingStation = await wateringStationViewModel.RetrieveWateringStation(Int32.Parse(wateringStationFullName.Substring(0, wateringStationFullName.IndexOf(" "))));
            if (existingStation)
            {
                wateringEventViewModel.stationFullName = wateringStationViewModel.FullName;
                wateringEventViewModel.wateringTime = Int32.Parse(stepperWateringTimeValue.Text);
                wateringEventViewModel.startTime = tpickerStartTime.Time.ToString();
                wateringEventViewModel.sunday = switchSunday.On;
                wateringEventViewModel.monday = switchMonday.On;
                wateringEventViewModel.tuesday = switchTuesday.On;
                wateringEventViewModel.wednesday = switchWednesday.On;
                wateringEventViewModel.thursday = switchThursday.On;
                wateringEventViewModel.friday = switchFriday.On;
                wateringEventViewModel.saturday = switchSaturday.On;
                bool stationAdded = await wateringEventViewModel.SaveWateringEvent();
                if (stationAdded)
                    await DisplayAlert("Info", string.Concat("Event added."), "OK");
            }
            else
                await DisplayAlert("Error", string.Concat("Error loading station."), "OK");
            await Navigation.PopAsync();
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void ChangedWateringTime(object sender, ValueChangedEventArgs e)
        {
            stepperWateringTimeValue.Text = stepperWateringTime.Value.ToString();
        }
    }
}
