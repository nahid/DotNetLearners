// See https://aka.ms/new-console-template for more information

using xWeather.InputHandler;

namespace xWeather
{
    using xWeather.Drivers;
    using ConsoleTables;
    class Program
    {
        static void Main(string[] args)
        {
            IInputHandler inputHandler = InputHandlerFactory.CreateInputHandler(args);

            string location = inputHandler.GetLocation();
            string provider = inputHandler.GetProvider();
            
            WeatherManager wm = new WeatherManager(provider);
            Task<WeatherData> weatherTask = wm.GetWeather(location);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Weather for {location} on " + weatherTask.Result.Time);
            Console.ResetColor();

            var table = new ConsoleTable("#", "Value");

            Console.BackgroundColor = ConsoleColor.DarkGray;
            table.AddRow("Tempurature", $"{weatherTask.Result.Temperature}°C");
            table.AddRow("Humidity", weatherTask.Result.Humidity);
            table.AddRow("Wind Speed", weatherTask.Result.WindSpeed);
            table.AddRow("Pressure", weatherTask.Result.Pressure);
            Console.ResetColor();

            table.Write();
        }
    }
}
