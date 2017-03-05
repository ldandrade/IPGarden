using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IPGarden.ViewModel;

using Xamarin.Forms;

namespace IPGarden.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            // Dictionary to get Color from color name.
            List<Station> stations = new List<Station>();
            stations.Add(new Station("Vazio", 1, false, 0));
            stations.Add(new Station("Vazio", 2, false, 0));
            stations.Add(new Station("Horta", 3, false, 10));
            stations.Add(new Station("Estufa", 4, false, 10));
            stations.Add(new Station("Pomar (área alta)", 5, false, 10));
            stations.Add(new Station("Pomar (área baixa)", 6, false, 10));
            stations.Add(new Station("Vazio", 7, false, 10));
            stations.Add(new Station("Jardim frontal", 8, false, 0));

            InitializeComponent();

            stationsList.ItemsSource = stations;
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
    }
}
