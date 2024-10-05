﻿// See https://aka.ms/new-console-template for more information

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

            if (args.Length == 0)
            {
                // If no arguments, prompt the user to enter a location
                Console.WriteLine("No location provided. Please enter the location:");
                location = Console.ReadLine();

                if (string.IsNullOrEmpty(location))
                {
                    Console.WriteLine("No location found!");
                    return;
                }
            }
            else
            {
                // If arguments are provided, use the first one as the location
                location = args[0];
            }
            

            Console.WriteLine($"len: {args.Length}, location: {location}");


            if (location == null)
            {
                Console.WriteLine("No location found!");
                return;
            }

            if (args.Length > 1 && args[1] == "-p")
            {
                if (args.Length < 3)
                {
                    Console.WriteLine("No provider found!");
                    return;
                }

                provider = args[2];

            }

            WeatherManager wm = new WeatherManager(provider);
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
