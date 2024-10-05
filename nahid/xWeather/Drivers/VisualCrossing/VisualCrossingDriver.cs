using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xWeather.Drivers.VisualCrossing.Responses;
using System.Net.Http;
using System.Text.Json;

namespace xWeather.Drivers.VisualCrossing
{
    internal class VisualCrossingDriver : IWeatherDriver
    {
        private const string ApiKey = "FLZFNFJYXPGPMBE86U7P37DKP";
        private const string BaseUrl = "https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services";

        public Task<WeatherData> GetWeather(string location)
        {
            return Task.Run(() =>
            {
                using (var client = new HttpClient())
                {
                    var today = DateTime.Now.ToString("yyyy-M-d");
                    var response = client.GetAsync($"{BaseUrl}/timeline/{location}/{today}/{today}?key={ApiKey}").Result;
                    var content = response.Content.ReadAsStringAsync().Result;

                    var weatherResponse = JsonSerializer.Deserialize<Response>(content);

                    if (weatherResponse == null)
                    {
                        throw new Exception("Failed to get weather data");
                    }

                    return new WeatherData
                    {
                        Location = location,
                        Condition = weatherResponse.Current.Condition,
                        Temperature =(int) ((weatherResponse.Current.Temperature - 32) * (5.0 / 9)),
                        Humidity = weatherResponse.Current.Humidity,
                        WindSpeed = weatherResponse.Current.WindSpeed,
                        Pressure = weatherResponse.Current.Pressure,
                        Time = DateTime.Now
                    };
                }
            });
        }
    }
}
