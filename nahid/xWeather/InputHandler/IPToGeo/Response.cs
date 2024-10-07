using System.Text.Json.Serialization;

namespace xWeather.InputHandler.IPToGeo
{
    internal class Response
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = "Dhaka";

        [JsonPropertyName("region")]
        public string Region { get; set; } = "Dhaka";

        [JsonPropertyName("country")]
        public string Country { get; set; } = "Bangladesh";
    }
}
