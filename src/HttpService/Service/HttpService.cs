using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using HttpService.Helpers;

namespace HttpService.Service;

public class HttpService : IHttpService
{
    private readonly HttpClient _client;

    public HttpService(HttpClient client)
    {
        _client = client;
    }

    public async Task<ResponseWrapper<T?>> Get<T>(string url)
    {
        var response = await _client.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper<T?>(false, default, response);

        var data = await response.Content.ReadFromJsonAsync<T>(Options);

        return new ResponseWrapper<T?>(true, data, response);
    }

    private static JsonSerializerOptions Options => new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    };
    
}