using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Irrigatus.View;
using Irrigatus.ViewModel;
using Irrigatus.Database;
using Irrigatus.Service;

using Xamarin.Forms;

namespace Irrigatus
{
    public partial class App : Application
    {
        public static ArduinoRestService restService;
        private static IrrigatusDatabase database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Irrigatus.View.RootPage());
            restService = new ArduinoRestService();
        }

        public static IrrigatusDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new IrrigatusDatabase(DependencyService.Get<IFileHelper>().GetLocalFilePath("IrrigatusDB.db3"));
                }
                return database;
            }
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
