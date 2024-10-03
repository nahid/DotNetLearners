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
        public float Temperature { get; set; }
        [JsonPropertyName("wind_kph")]
        public float WindSpeed { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("pressure_mb")]
        public float Pressure { get; set; }
        [JsonPropertyName("Time")]
        public DateTime Time { get; set; }
        [JsonPropertyName("condition")]
        public Condition Condition { get; set; } = new Condition();
    }
}
