using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Irrigatus.Model;
using Irrigatus.ViewModel;

using Xamarin.Forms;

namespace Irrigatus.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            // Dictionary to get Color from color name.
            /**List<WateringStation> stations = new List<WateringStation>();
            stations.Add(new WateringStation("Vazio", 1, false, 0));
            stations.Add(new WateringStation("Vazio", 2, false, 0));
            stations.Add(new WateringStation("Horta", 3, false, 10));
            stations.Add(new WateringStation("Estufa", 4, false, 10));
            stations.Add(new WateringStation("Pomar (área alta)", 5, false, 10));
            stations.Add(new WateringStation("Pomar (área baixa)", 6, false, 10));
            stations.Add(new WateringStation("Vazio", 7, false, 10));
            stations.Add(new WateringStation("Jardim frontal", 8, false, 0));**/

            InitializeComponent();

            //stationsList.ItemsSource = stations;
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
            var addWateringStationModalPage = new AddEditWateringStationModalPage();
            await Navigation.PushModalAsync(addWateringStationModalPage);
        }

        private void EditButtonClicked(object sender, EventArgs e)
        {

        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {

        }
    }
}
