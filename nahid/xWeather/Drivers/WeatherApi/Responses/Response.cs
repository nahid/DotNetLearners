using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace xWeather.Drivers.WeatherApi.Responses
{
    internal class Response
    {
        [JsonPropertyName("current")]
        public Current Current { get; set; } = new Current();

        [JsonPropertyName("location")]
        public Location Location { get; set; } = new Location();
    }
}
