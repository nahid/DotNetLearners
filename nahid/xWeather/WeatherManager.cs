using xWeather.Drivers;
using xWeather.Drivers.VisualCrossing;
using xWeather.Drivers.WeatherApi;
using Newtonsoft.Json.Linq;

namespace xWeather
{
    internal class WeatherManager
    {
        private readonly IWeatherDriver _driver;

        public WeatherManager(string provider)
        {
            _driver = provider switch
            {
                "weatherapi" => new WeatherApiDriver(),
                "visualcrossing" => new VisualCrossingDriver(),
                _ => throw new ArgumentException("Invalid provider")
            };


        }

        public async Task<WeatherData> GetWeather(string location)
        {
            return await _driver.GetWeather(location);
        }

        public static Task<string> GetLocation()
        {
            return Task.Run(static () =>
            {
                using (var client = new HttpClient())
                {
                    string apiKey = "f0c54c1856b5cc";
                    string url = $"https://ipinfo.io/json?token={apiKey}";
                    string city = "Dhaka";
                    try
                    {
                        HttpResponseMessage response = client.GetAsync(url).Result;
                        var content = response.Content.ReadAsStringAsync().Result ?? throw new Exception("Failed to get location data");
                        JObject locationData = JObject.Parse(content);
                        city = locationData["city"].ToString();

                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine("Request error: " + e.Message);
                    }

                    return city;
                }
            });
        }
    }
}
