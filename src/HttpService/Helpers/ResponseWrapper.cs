using System.Net;

namespace HttpService.Helpers;

public record ResponseWrapper<T>(bool Success, T Data, HttpStatusCode StatusCode, string? ErrorMessage = null)
{
    
};
public record ResponseWrapper(bool Success, HttpStatusCode StatusCode, string? ErrorMessage = null);