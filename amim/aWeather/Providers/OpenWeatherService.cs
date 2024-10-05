using aWeather.Models;
using aWeather.Utilities;

namespace aWeather.Providers;

public class OpenWeatherService : IWeatherProvider
{
    private readonly ApiClient _apiClient;
    private const string ApiKey = "bd5e378503939ddaee76f12ad7a97608";
    private const string BaseUrl = "https://api.openweathermap.org/data/2.5/weather";

    public OpenWeatherService(ApiClient apiClient)
    {
        _apiClient = apiClient;
    }

    public WeatherInfo GetWeather(string location)
    {
        string url = $"{BaseUrl}?q={location}&appid={ApiKey}&units=metric";
        var response = _apiClient.Get(url);

        // For brevity, the parsing is simplified. In a real app, use a JSON library like Newtonsoft.Json or System.Text.Json.
        return new WeatherInfo
        {
            Location = location,
            Temperature = double.Parse(response["main"]["temp"].ToString()),
            Condition = response["weather"][0]["description"].ToString(),
            Humidity = int.Parse(response["main"]["humidity"].ToString()),
            WindSpeed = double.Parse(response["wind"]["speed"].ToString())
        };
    }
}