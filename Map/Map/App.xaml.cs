using System;
using Xamarin.Forms;
using Map.Model;
using Map.Services;
using Xamarin.Forms.Xaml;

using Map.Views;

namespace Map
{
    public partial class App : Application
    {
        public static TodoManager TodoManager { get; set; }
        public App()
        {
            InitializeComponent();
            TodoManager = new TodoManager(new RestService());

            MainPage = new WeatherPage();
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
