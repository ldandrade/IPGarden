using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;
using Irrigatus.ViewModel;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Irrigatus.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            stationsList.ItemsSource = await AllWateringStationViewModel.RetrieveWateringStationsAsync();
        }

        private async void OnItemToggled(object sender, ToggledEventArgs e)
        {
            SwitchCell toggledSwitch = (SwitchCell)sender;
            string stationID = toggledSwitch.Text.Substring(0, toggledSwitch.Text.IndexOf(" "));
            int status = await App.restService.ActivateSwitchAsync(stationID);
            if (status==1)
                await DisplayAlert("Info", string.Concat("Station ",stationID," activated"), "OK");
            else if (status==0)
                await DisplayAlert("Info", string.Concat("Station ", stationID, " deactivated"), "OK");
            else if (status==-1)
                await DisplayAlert("Error", string.Concat("Failed to activate station ", stationID), "OK");
        }

        private async void RefreshButtonClicked(object sender, EventArgs e)
        {
            sensorActivityIndicator.IsRunning = true;
            int temperature = await App.restService.ReadTemperatureAsync();
            int humidity = await App.restService.ReadHumidityAsync();
            labelTempValue.Text = temperature.ToString();
            labelHumValue.Text = humidity.ToString();
            sensorActivityIndicator.IsRunning = false;
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditWateringStationModalPage());
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {

        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
