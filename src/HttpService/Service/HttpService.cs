using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using HttpService.Extensions;
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

    public async Task<ResponseWrapper<TResponse?>> Post<T, TResponse>(string url, T data)
    {
        var response = await _client.PostAsJsonAsync(url, data);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper<TResponse?>(false, default, response);
        
        var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(Options);
        
        return new ResponseWrapper<TResponse?>(true, dataResponse, response);
    }

    public async Task<ResponseWrapper<object>> Post<T>(string url, T data)
    {
        var response = await _client.PostAsJsonAsync(url, data);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper<object>(false, false, response);

        return new ResponseWrapper<object>(true, true, response);
    }

    public async Task<ResponseWrapper<object>> Put<T>(string url, T data)
    {
        var response = await _client.PutAsJsonAsync(url, data);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper<object>(false, false, response);

        return new ResponseWrapper<object>(true, true, response);
    }

    public async Task<ResponseWrapper<object>> Patch<T>(string url, T data)
    {
        var response = await _client.PatchAsJsonAsync(url, data, Options);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper<object>(false, false, response);

        return new ResponseWrapper<object>(true, true, response);
    }

    private static JsonSerializerOptions Options => new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
    
}