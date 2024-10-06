namespace xWeather.InputHandler;

public static class DefaultInputHandlerFactory{
    public static IInputHandler CreateInputHandler(string[] args){

        return new DefaultArgumentInputHandler(args);
    }
}

