using aWeather.Models;
using aWeather.Providers;

namespace aWeather.Services;

public class WeatherService
{
    private readonly List<IWeatherProvider> _providers;

    public WeatherService()
    {
        _providers = new List<IWeatherProvider>();
    }

    public void RegisterProvider(IWeatherProvider provider)
    {
        _providers.Add(provider);
    }

    public WeatherInfo GetWeather(string providerName, string location)
    {
        var provider = _providers.Find(p => p.GetType().Name.Contains(providerName, StringComparison.OrdinalIgnoreCase));

        if (provider == null)
        {
            throw new Exception("Weather provider not found.");
        }

        return provider.GetWeather(location);
    }
}