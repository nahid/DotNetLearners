using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace xWeather.Drivers.VisualCrossing.Responses
{
    internal class Current
    {
        [JsonPropertyName("temp")]
        public double Temperature { get; set; }
        [JsonPropertyName("windspeed")]
        public double WindSpeed { get; set; }
        [JsonPropertyName("humidity")]
        public double Humidity { get; set; }
        [JsonPropertyName("pressure")]
        public double Pressure { get; set; }
        [JsonPropertyName("conditions")]
        public string Condition { get; set; } = "";
    }
}
