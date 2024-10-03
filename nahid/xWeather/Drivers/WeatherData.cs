using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xWeather.Drivers
{
    internal class WeatherData
    {
        public string Location { get; set; }
        public string Condition { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
        public DateTime Time { get; set; }
    }
}
