using System;
using System.Threading.Tasks;
using Irrigatus.ViewModel;

using Xamarin.Forms;
using System.Threading;

namespace Irrigatus.View
{
    public partial class MainPage : ContentPage
    {
        AllWateringStationViewModel wateringStationsViewModel;

        public MainPage()
        {
            InitializeComponent();
            wateringStationsViewModel = new AllWateringStationViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                serviceActivityIndicator.IsRunning = true;
                await wateringStationsViewModel.RetrieveWateringStationsFromDBAsync();
                //await wateringStationsViewModel.UpdateWateringStationRelayStatusAsync();
                this.BindingContext = this.wateringStationsViewModel;
                int temperature = await App.restService.ReadTemperatureAsync();
                int humidity = await App.restService.ReadHumidityAsync();
                labelTempValue.Text = temperature.ToString();
                labelHumValue.Text = humidity.ToString();
                serviceActivityIndicator.IsRunning = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", String.Concat("Failed to connect to Relay Panel - ", ex.Message), "Ok");
            }
            finally
            {
                serviceActivityIndicator.IsRunning = false;
            }
        }

        private async void OnItemToggled(object sender, ToggledEventArgs e)
        {
            try
            {
                serviceActivityIndicator.IsRunning = true;
                SwitchCell toggledSwitch = (SwitchCell)sender;
                string stationID = toggledSwitch.Text.Substring(0, toggledSwitch.Text.IndexOf(" "));
                WateringStationViewModel wsvm = new WateringStationViewModel(int.Parse(stationID));
                bool stationActive = await App.restService.GetSwitchStateAsync(stationID);
                bool switchOn = toggledSwitch.On;
                if (!stationActive && switchOn)
                {
                    stationActive = await App.restService.ActivateSwitchAsync(stationID);
                    Device.StartTimer(new TimeSpan(0, 0, 0, 0, wsvm.WateringTime * 60 * 100), () => 
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await wateringProgressBar.ProgressTo(wateringProgressBar.Progress + 0.1, 1000, Easing.SinOut);
                        });
                        if (wateringProgressBar.Progress == 1)
                        {
                            toggledSwitch.On = false;
                            return false;
                        }
                        else
                            return true;
                    });
                    await DisplayAlert("Info", string.Concat("Station ", stationID, " activated"), "OK");
                }
                else if (stationActive && !switchOn)
                {
                    stationActive = await App.restService.ActivateSwitchAsync(stationID);
                    wateringProgressBar.Progress = 0.0;
                    await DisplayAlert("Info", string.Concat("Station ", stationID, " deactivated"), "OK");
                }
                serviceActivityIndicator.IsRunning = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", String.Concat("Failed to connect to Relay Panel - ", ex.Message), "Ok");
            }
            finally
            {
                serviceActivityIndicator.IsRunning = false;
            }
        }

        private async void RefreshButtonClicked(object sender, EventArgs e)
        {
            try
            {
                serviceActivityIndicator.IsRunning = true;
                int temperature = await App.restService.ReadTemperatureAsync();
                int humidity = await App.restService.ReadHumidityAsync();
                labelTempValue.Text = temperature.ToString();
                labelHumValue.Text = humidity.ToString();
                serviceActivityIndicator.IsRunning = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", String.Concat("Failed to connect to Relay Panel - ", ex.Message), "Ok");
            }
            finally
            {
                serviceActivityIndicator.IsRunning = false;
            }
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditWateringStationModalPage());
            await wateringStationsViewModel.RetrieveWateringStationsFromDBAsync();
            this.BindingContext = this.wateringStationsViewModel;
        }

        private async void EditButtonClicked(object sender, EventArgs e)
        {
            SwitchCell toggledSwitch = (SwitchCell) sender;
            string stationID = toggledSwitch.Text.Substring(0, toggledSwitch.Text.IndexOf(" "));
            WateringStationViewModel selectedStation = new WateringStationViewModel();
            bool stationFound = await selectedStation.RetrieveWateringStation(Int32.Parse(stationID));
            if (stationFound)
            {
                await Navigation.PushAsync(new AddEditWateringStationModalPage(selectedStation));
                //stationsList.ItemsSource = await AllWateringStationViewModel.RetrieveWateringStationsAsync();
            }
            else
                await DisplayAlert("Error", string.Concat("Failed to locate station ", stationID, " on the database"), "OK");
        }
    }
}
