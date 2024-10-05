using aWeather.Models;

namespace aWeather.Providers;

public interface IWeatherProvider
{
    WeatherInfo GetWeather(string location);
}