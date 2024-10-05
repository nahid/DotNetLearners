using aWeather.Providers;
using aWeather.Services;
using aWeather.Utilities;

namespace xWeather;

class Program
{
    static void Main(string[] args)
    {
        // Initialize services and providers
        ApiClient apiClient = new ApiClient();
        WeatherService weatherService = new WeatherService();

        // Register weather providers
        weatherService.RegisterProvider(new OpenWeatherService(apiClient));

        Console.WriteLine("Welcome to the Weather App!");

        // Select provider
        Console.WriteLine("Select a Weather Provider:");
        Console.WriteLine("1. OpenWeatherMap");

        Console.Write("Enter provider number: ");
        string providerSelection = Console.ReadLine();

        string providerName = providerSelection switch
        {
            "1" => "OpenWeather",
            _ => throw new Exception("Invalid provider selection.")
        };

        // Input location
        Console.Write("Enter your location (e.g., city name): ");
        string location = Console.ReadLine();

        // Fetch and display weather
        try
        {
            var weatherInfo = weatherService.GetWeather(providerName, location);
            Console.WriteLine($"\nWeather in {weatherInfo.Location}:");
            Console.WriteLine($"Temperature: {weatherInfo.Temperature}°C");
            Console.WriteLine($"Condition: {weatherInfo.Condition}");
            Console.WriteLine($"Humidity: {weatherInfo.Humidity}%");
            Console.WriteLine($"Wind Speed: {weatherInfo.WindSpeed} km/h");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching weather data: {ex.Message}");
        }

        Console.ReadLine(); // Keep console open
    }
}