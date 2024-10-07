using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace xWeather.Drivers.WeatherApi.Responses
{
    internal class Location
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = "";
        [JsonPropertyName("region")]
        public string Region { get; set; } = "";
        [JsonPropertyName("country")]
        public string Country { get; set; } = "";
    
        [JsonPropertyName("localtime")]
        public string Time { get; set; } = "";
    }
}
