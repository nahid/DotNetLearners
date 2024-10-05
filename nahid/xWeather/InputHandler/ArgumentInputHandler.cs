namespace xWeather.InputHandler;

public class ArgumentInputHandler: IInputHandler
{
    private readonly string[] _args;

    public ArgumentInputHandler(string[] args)
    {
        _args = args;
    }

    public string GetLocation()
    {
        if (_args.Length == 0)
        {
            throw new ArgumentException("No location provided in arguments.");
        }

        return _args[0];
    }

    public string GetProvider()
    {
        if (_args.Length > 1 && _args[1] == "-p" && _args.Length >= 3)
        {
            return _args[2];
        }

        return "weatherapi"; // default provider
    }
}