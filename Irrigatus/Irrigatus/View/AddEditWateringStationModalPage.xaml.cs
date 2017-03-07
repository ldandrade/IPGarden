using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Irrigatus.ViewModel;

namespace Irrigatus.View
{
    public partial class AddEditWateringStationModalPage : ContentPage
    {
        WateringStationViewModel wateringStationViewModel;

        public AddEditWateringStationModalPage()
        {
            InitializeComponent();
        }

        public AddEditWateringStationModalPage(WateringStationViewModel wateringStationViewModel)
        {
            InitializeComponent();
            entryRelayPanelStationNumber.Text = wateringStationViewModel.number.ToString();
            entryWateringStationName.Text = wateringStationViewModel.name;
            entryWateringTime.Text = wateringStationViewModel.wateringTime.ToString();
        }

        private async void OkButtonClicked(object sender, EventArgs e)
        {
            wateringStationViewModel = new WateringStationViewModel();
            wateringStationViewModel.number = Int32.Parse(entryRelayPanelStationNumber.Text);
            wateringStationViewModel.name = entryWateringStationName.Text;
            wateringStationViewModel.wateringTime = Int32.Parse(entryWateringTime.Text);
            bool stationAdded = await wateringStationViewModel.SaveWateringStation();
            if (stationAdded)
                await DisplayAlert("Info", string.Concat("Station ", wateringStationViewModel.fullName, " added."), "OK");
            await Navigation.PopAsync();
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
