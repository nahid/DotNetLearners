using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xWeather.Drivers
{
    internal interface IWeatherDriver
    {
        Task<WeatherData> GetWeather(string location);
    }
}
