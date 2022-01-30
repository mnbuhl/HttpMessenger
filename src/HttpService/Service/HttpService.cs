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
        var response = await _client.PostAsJsonAsync(url, data, Options);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper<TResponse?>(false, default, response);
        
        var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(Options);
        
        return new ResponseWrapper<TResponse?>(true, dataResponse, response);
    }

    public async Task<ResponseWrapper> Post<T>(string url, T data)
    {
        var response = await _client.PostAsJsonAsync(url, data, Options);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper(false, response);

        return new ResponseWrapper(true, response);
    }

    public async Task<ResponseWrapper> Put<T>(string url, T data)
    {
        var response = await _client.PutAsJsonAsync(url, data, Options);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper(false, response);

        return new ResponseWrapper(true, response);
    }

    public async Task<ResponseWrapper> Patch<T>(string url, T data)
    {
        var response = await _client.PatchAsJsonAsync(url, data, Options);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper(false, response);

        return new ResponseWrapper(true, response);
    }

    public async Task<ResponseWrapper> Delete<T>(string url)
    {
        var response = await _client.DeleteAsync(url);
        
        if (!response.IsSuccessStatusCode)
            return new ResponseWrapper(false, response);
        
        return new ResponseWrapper(true, response);
    }


    private static JsonSerializerOptions Options => new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
    
}