using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IPGarden.View;
using IPGarden.ViewModel;

using Xamarin.Forms;

namespace IPGarden
{
    public partial class App : Application
    {
        public static ArduinoRestService restService;

        public App()
        {
            InitializeComponent();

            MainPage = new IPGarden.View.RootPage();
            restService = new ArduinoRestService();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
