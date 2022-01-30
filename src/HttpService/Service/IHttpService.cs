using HttpService.Helpers;

namespace HttpService.Service;

public interface IHttpService
{
    Task<ResponseWrapper<T?>> Get<T>(string url);
    Task<ResponseWrapper<TResponse?>> Post<T, TResponse>(string url, T data);
    Task<ResponseWrapper> Post<T>(string url, T data);
    Task<ResponseWrapper> Put<T>(string url, T data);
    Task<ResponseWrapper> Patch<T>(string url, T data);
    Task<ResponseWrapper> Delete(string url);
}