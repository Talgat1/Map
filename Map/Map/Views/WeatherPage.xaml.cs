using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Map.Model;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;


namespace Map.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        Rootobject rot;
        CancellationTokenSource tok;
        Pin p = new Pin();
        public WeatherPage()
        {
            InitializeComponent();
            //var res = GetLocation();
            p.Label = "";
            p.Address = "";
            p.Position = new Position();
            MyMap.Pins.Add(p);
        }
        async Task<Location> GetLocation()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High, TimeSpan.FromSeconds(15));
            tok = new CancellationTokenSource();
            var location = await Geolocation.GetLocationAsync(request, tok.Token);
            if (location != null)
            {
                p.Label = rot.name;
                p.Position = new Position(rot.coord.lat, rot.coord.lon);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), new Distance(100d)));
            }
            return location;

        }
        protected override void OnAppearing()
        {
            if (tok != null && !tok.IsCancellationRequested)
            {
                tok.Cancel();
            }
            base.OnAppearing();
        }

        private async void SearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            try
            {
                rot = await App.TodoManager.GetTodoItemModels(searchbarcity.Text);
                BindingContext = rot.main;
                Temp.Text = $"Температура: {rot.main.temp}°C";
                Fells.Text = $"Ощущается как: {rot.main.feels_like}°C";
                Wind.Text = $"Ветер: {rot.wind.speed} м/с";
                Hum.Text = $"Влажность: {rot.main.humidity}%";
                Pressure.Text = $"Атмосферное давление: {rot.main.pressure} мм.р.с.";
                imagecloud.Source = ImageSource.FromUri(new Uri($"http://openweathermap.org/img/wn/{rot.weather[0].icon}.png"));
                await GetLocation();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ошибка, введите город\n{ex.Message}", "Ok");
            }
        }
    }
}