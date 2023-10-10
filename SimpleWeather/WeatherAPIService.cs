using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWeather
{
    static class WeatherAPIService
    {
        static string baseURL = "https://api.openweathermap.org/data/2.5/forecast?lat=44.34&lon=10.99&appid=";

        public static async Task<List<string>> GetTemp ()
        {
            List<string> temps = new List<string>();

            string endpoint = baseURL + "temp";

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, endpoint);
            request.Headers.Add("apikey", "557e4ffb0a6ad8eb685bb13051d4a230");
            HttpResponseMessage response = await client.SendAsync(request);

            if(response.IsSuccessStatusCode)
            {
                WeatherResponseModel model = (WeatherResponseModel)await response.Content.ReadFromJsonAsync(typeof(WeatherResponseModel));
            }

            return temps;
        }
    }
}
