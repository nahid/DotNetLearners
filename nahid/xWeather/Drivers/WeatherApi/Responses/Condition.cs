using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace xWeather.Drivers.WeatherApi.Responses
{
    internal class Condition
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = "";
    }
}
