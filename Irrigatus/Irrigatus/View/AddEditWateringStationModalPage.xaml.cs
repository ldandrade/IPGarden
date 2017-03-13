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
            stepperWateringTimeValue.Text = wateringStationViewModel.wateringTime.ToString();
            stepperWateringTime.Value = Int32.Parse(stepperWateringTimeValue.Text);
        }

        private async void OkButtonClicked(object sender, EventArgs e)
        {
            wateringStationViewModel = new WateringStationViewModel(Int32.Parse(entryRelayPanelStationNumber.Text));
            wateringStationViewModel.number = Int32.Parse(entryRelayPanelStationNumber.Text);
            wateringStationViewModel.name = entryWateringStationName.Text;
            wateringStationViewModel.wateringTime = Int32.Parse(stepperWateringTimeValue.Text);
            bool stationAdded = await wateringStationViewModel.SaveWateringStation();
            if (stationAdded)
                await DisplayAlert("Info", string.Concat("Station ", wateringStationViewModel.fullName, " added."), "OK");
            await Navigation.PopAsync();
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void DeleteButtonClicked(object sender, EventArgs e)
        {
            wateringStationViewModel = new WateringStationViewModel(Int32.Parse(entryRelayPanelStationNumber.Text));
            bool stationDeleted = await wateringStationViewModel.DeleteWateringStation();
            if (stationDeleted)
                await DisplayAlert("Info", string.Concat("Station ", wateringStationViewModel.fullName, " deleted."), "OK");
            await Navigation.PopAsync();
        }

        private void ChangedWateringTime(object sender, ValueChangedEventArgs e)
        {
            stepperWateringTimeValue.Text = stepperWateringTime.Value.ToString();
        }
    }
}
