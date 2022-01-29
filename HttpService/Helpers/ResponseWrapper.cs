namespace HttpService.Helpers;

public record ResponseWrapper<T>(bool Success, T Data, HttpResponseMessage ResponseMessage);