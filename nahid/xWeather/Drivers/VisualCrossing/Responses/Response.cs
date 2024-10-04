using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace xWeather.Drivers.VisualCrossing.Responses
{
    internal class Response
    {
        [JsonPropertyName("currentConditions")]
        public Current Current { get; set; } = new Current();
    }
}
