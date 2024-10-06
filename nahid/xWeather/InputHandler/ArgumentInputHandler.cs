namespace xWeather.InputHandler;

public class ArgumentInputHandler : IInputHandler
{
    private readonly string[] _args;

    public ArgumentInputHandler(string[] args)
    {
        _args = args;
    }

    public string GetLocation()
    {
        string location = "";
        if (_args.Length == 0)
        {
            Task<string> currentLocation = WeatherManager.GetLocation();
            location = currentLocation.Result;
            //throw new ArgumentException("No location provided in arguments.");
        }
        else if (_args[0] != "-p" || _args[0] != "--p")
        {
            location = _args[0].Trim();
        }

        return location;
    }

    public string GetProvider()
    {
        string provider = "weatherapi";
        if (_args.Length > 0)
        {
            if (_args[0] != "-p" || _args[0] != "--p")
            {
                if (_args.Length > 1 && (_args[1] != "-p" || _args[1] != "--p"))
                {
                    if (_args.Length > 2 && !string.IsNullOrEmpty(_args[2]))
                    {
                        provider = _args[2].Trim();
                    }
                }
            }
            else if (_args[0] != "-p" || _args[0] != "--p")
            {
                if (_args.Length > 1 && !string.IsNullOrEmpty(_args[1]))
                {
                    provider = _args[1].Trim();
                }
            }
        }

        return provider; // default provider
    }
}