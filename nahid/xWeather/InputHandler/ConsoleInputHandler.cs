namespace xWeather.InputHandler;

public class ConsoleInputHandler: IInputHandler
{
    public string GetLocation()
    {
        Console.WriteLine("Enter location:");
        return Console.ReadLine() ?? throw new ArgumentException("No location entered.");
    }

    public string GetProvider()
    {
        Console.WriteLine("Enter provider (default: weatherapi):");
        var provider = Console.ReadLine();
        return string.IsNullOrEmpty(provider) ? "weatherapi" : provider;
    }
}