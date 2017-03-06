using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Irrigatus.View
{

    public partial class RootPage : TabbedPage
    {
        public RootPage()
        {
            InitializeComponent();

            Children.Add(new MainPage());
            Children.Add(new ProgramPage());
            Children.Add(new SettingsPage());
        }
    }
}
