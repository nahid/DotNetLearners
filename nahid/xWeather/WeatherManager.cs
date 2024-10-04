using xWeather.Drivers;
using xWeather.Drivers.VisualCrossing;
using xWeather.Drivers.WeatherApi;

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
    }
}
