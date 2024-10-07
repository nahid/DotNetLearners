namespace xWeather.InputHandler;

public static class InputHandlerFactory
{
    public static IInputHandler CreateInputHandler(string[] args)
    {
        if (args.Length > 0)
        {
            return new ArgumentInputHandler(args);
        }

        return new DefaultArgumentInputHandler(args);

    }
}