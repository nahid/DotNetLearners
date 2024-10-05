using Newtonsoft.Json.Linq;

namespace aWeather.Utilities;

using System.Net.Http;

public class ApiClient
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
    }

    public JObject Get(string url)
    {
        var response = _httpClient.GetStringAsync(url).Result;
        return JObject.Parse(response); // Using Newtonsoft.Json for JSON parsing
    }
}