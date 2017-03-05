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
            stations.Add(new Station("Empty", 1, false, 0));
            stations.Add(new Station("Empty", 2, false, 0));
            stations.Add(new Station("Greenhouse", 3, false, 10));
            stations.Add(new Station("Veggies Garden", 4, false, 10));
            stations.Add(new Station("Orchard (lower area)", 5, false, 10));
            stations.Add(new Station("Orchard (upper area)", 6, false, 10));
            stations.Add(new Station("Front Garden", 7, false, 10));
            stations.Add(new Station("Empty", 8, false, 0));

            InitializeComponent();

            stationsList.ItemsSource = stations;
        }


        private void OnItemToggled(object sender, ToggledEventArgs e)
        {

        }
    }
}
