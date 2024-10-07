using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace xWeather.Drivers.WeatherApi.Responses
{
    internal class Current
    {
        [JsonPropertyName("temp_c")]
        public double Temperature { get; set; }
        [JsonPropertyName("wind_kph")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
        [JsonPropertyName("pressure_mb")]
        public double Pressure { get; set; }
       
        [JsonPropertyName("condition")]
        public Condition Condition { get; set; } = new Condition();
    }
}
