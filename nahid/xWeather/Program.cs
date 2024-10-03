// See https://aka.ms/new-console-template for more information

namespace xWeather
{
    using xWeather.Drivers.WeatherApi;
    using xWeather.Drivers;
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherDriver driver = new WeatherApiDriver();
            Task<WeatherData> weatherTask = driver.GetWeather("London");
            Console.WriteLine(weatherTask.Result.Temperature);

        }
    }
}
