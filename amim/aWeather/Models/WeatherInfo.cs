namespace aWeather.Models;

public class WeatherInfo
{
    public string Location { get; set; }
    public double Temperature { get; set; }
    public string Condition { get; set; }
    public int Humidity { get; set; }
    public double WindSpeed { get; set; }
}