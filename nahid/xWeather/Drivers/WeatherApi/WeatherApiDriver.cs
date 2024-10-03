using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xWeather.Drivers.WeatherApi.Responses;
using System.Net.Http;
using System.Text.Json;

namespace xWeather.Drivers.WeatherApi
{
    internal class WeatherApiDriver : IWeatherDriver
    {
        private const string ApiKey = "8c3ba5adfbd44095958113304240310";
        private const string BaseUrl = "http://api.weatherapi.com/v1";

        public Task<WeatherData> GetWeather(string location)
        {
            return Task.Run(() =>
            {
                using (var client = new HttpClient())
                {
                    var response = client.GetAsync($"{BaseUrl}/current.json?key={ApiKey}&q={location}").Result;
                    var content = response.Content.ReadAsStringAsync().Result;
      
                    var weatherResponse = JsonSerializer.Deserialize<Response>(content);

                    if (weatherResponse == null)
                    {
                        throw new Exception("Failed to get weather data");
                    }

                    return new WeatherData
                    {
                        Location = location,
                        Condition = weatherResponse.Current.Condition.Text,
                        Temperature = weatherResponse.Current.Temperature,
                        Humidity = weatherResponse.Current.Humidity,
                        WindSpeed = weatherResponse.Current.WindSpeed,
                        Pressure = weatherResponse.Current.Pressure,
                        Time = weatherResponse.Current.Time
                    };
                }
            });
        }
    }
}
