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
        public AddEditWateringEventPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ObservableCollection<WateringStationViewModel> pickerList = await AllWateringStationViewModel.RetrieveWateringStationsAsync();
            foreach (WateringStationViewModel station in pickerList)
            {
                pickerRelayPanelStationNumber.Items.Add(station.fullName);
            }
        }

    private async void OkButtonClicked(object sender, EventArgs e)
        {
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
