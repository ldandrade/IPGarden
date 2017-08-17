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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgramPage : ContentPage
    {
        public ProgramPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            eventsList.ItemsSource = await AllWateringEventViewModel.RetrieveWateringEventsAsync();
        }

        private async void AddButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditWateringEventPage());
            eventsList.ItemsSource = await AllWateringEventViewModel.RetrieveWateringEventsAsync();
        }

        private async void EditCellTapped(object sender, EventArgs e)
        {
            ViewCell tappedCell = (ViewCell)sender;
            WateringEventViewModel selectedEvent = (WateringEventViewModel)tappedCell.BindingContext;
            await Navigation.PushAsync(new AddEditWateringEventPage(selectedEvent));
            eventsList.ItemsSource = await AllWateringEventViewModel.RetrieveWateringEventsAsync();
        }
    }
}
