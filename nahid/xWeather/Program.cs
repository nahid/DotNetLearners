// See https://aka.ms/new-console-template for more information

namespace xWeather
{
    using xWeather.Drivers;
    using ConsoleTables;
    class Program
    {
        static void Main(string[] args)
        {
            string? location = null;
            string provider = "weatherapi";
            
            if (args.Length != 0)
            {
                if (args[0] != "--p") 
                {
                    location = args[0].Trim();

                    if (args.Length > 1 && args[1] == "--p")  
                    {
                        if (args.Length > 2 && !string.IsNullOrEmpty(args[2]))
                        {
                            provider = args[2].Trim();
                        }
                    }
                }
                else if (args[0] == "--p")
                {
                    if (args.Length > 1 && !string.IsNullOrEmpty(args[1]))
                    {
                        provider = args[1].Trim();
                    }
                }
            }

            WeatherManager wm = new WeatherManager(provider);

            if(location==null){
                Task<string> currentLocation = WeatherManager.GetLocation();
                location = currentLocation.Result;
            }
            Console.WriteLine($"len: {args.Length}, location: {location}");

            Task<WeatherData> weatherTask = wm.GetWeather(location);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Weather for {location}");
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
