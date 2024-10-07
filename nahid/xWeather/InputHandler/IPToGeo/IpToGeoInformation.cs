using Newtonsoft.Json.Linq;

namespace xWeather.InputHandler.IPToGeo{
    internal class IPToGeoInformation{
        private const string Token = "f0c54c1856b5cc";
        private const string BaseUrl = "https://ipinfo.io/";

        public static Task<Response> GetDefaultLocation()
        {
            return Task.Run( () =>
            {
                using (var client = new HttpClient())
                {
                    string url = $"{BaseUrl}json?token={Token}";
                    var response = client.GetAsync(url).Result;
                    var content = response.Content.ReadAsStringAsync().Result ?? throw new Exception("Failed to get location data");
                    
                    JObject ipGeoResponse = JObject.Parse(content);
                    
                    if(ipGeoResponse == null){
                        throw new Exception("Failed to load Geo Data!");
                    }

                    return new Response{
                        City = ipGeoResponse["city"].ToString(),
                        Region = ipGeoResponse["region"].ToString(),
                        Country = ipGeoResponse["country"].ToString(),
                    };
                }
            });
        }
    }
}