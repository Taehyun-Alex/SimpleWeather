using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleWeather.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather.Models.ViewModels
{
    internal partial class MainPageView : ObservableObject
    {
        private readonly WeatherAPIService _weatherApiService;

        public MainPageView()
        {
            _weatherApiService = new WeatherAPIService();
        }

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private float temperature;

        [RelayCommand]
        private async Task FetchWeatherInformation()
        {
            var weatherApiResponse = await _weatherApiService.GetWeatherInformation();
            if (weatherApiResponse != null)
            {
                Temperature = weatherApiResponse.main.temp;
            }
        }
    }
}
