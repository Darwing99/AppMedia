using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMedia
{
    public partial class App : Application
    {

        public static string UBICACIONDB;
        public App(string dblocal)
        {

            InitializeComponent();
            UBICACIONDB = dblocal;
            MainPage = new NavigationPage(new MainPage());

        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
