using HttpService.Helpers;

namespace HttpService.Service;

public interface IHttpService
{
    Task<ResponseWrapper<T?>> Get<T>(string url);
}