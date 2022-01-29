using HttpService.Helpers;

namespace HttpService.Service;

public interface IHttpService
{
    Task<ResponseWrapper<T?>> Get<T>(string url);
    Task<ResponseWrapper<TResponse?>> Post<T, TResponse>(string url, T data);
    Task<ResponseWrapper<object>> Post<T>(string url, T data);
    
}