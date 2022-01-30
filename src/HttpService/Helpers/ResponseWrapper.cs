using System.Net;

namespace HttpService.Helpers;

/// <summary>
/// A generic easy to use helper class for wrapping the content from a HTTP response.
/// </summary>
/// <param name="Success">The success status of the response</param>
/// <param name="Data">The data returned from the response</param>
/// <param name="StatusCode">The status code of the response</param>
/// <param name="ErrorMessage">Optional error message - used when the request fails</param>
/// <typeparam name="T">The generic data model returned from the response</typeparam>
public record ResponseWrapper<T>(bool Success, T Data, int StatusCode, string? ErrorMessage = null);

/// <summary>
/// An easy to use helper class for wrapping the content from a HTTP response.
/// </summary>
/// <param name="Success">The success status of the response</param>
/// <param name="StatusCode">The status code of the response</param>
/// <param name="ErrorMessage">Optional error message - used when the request fails</param>
public record ResponseWrapper(bool Success, int StatusCode, string? ErrorMessage = null);