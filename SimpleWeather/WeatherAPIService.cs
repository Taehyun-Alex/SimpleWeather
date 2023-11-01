using Newtonsoft.Json;
using SimpleWeather.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather
{
    public class WeatherAPIService //this class has a method that connects the API and returns json object
    {

        public static async Task<Root> GetWeatherInformation()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(string.Format("https://pro.openweathermap.org/data/2.5/forecast/hourly?q=perth&appid=59a4ade3192313d407110c1eb429f1a8&units=metric&cnt=10"));
            return JsonConvert.DeserializeObject<Root>(response);
        }
        
    }
}
