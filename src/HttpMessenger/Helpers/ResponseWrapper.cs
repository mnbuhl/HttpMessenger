using System.Net;

namespace HttpMessenger.Helpers
{
    /// <summary>
    /// A generic easy to use helper class for wrapping the content from a HTTP response.
    /// </summary>
    /// <typeparam name="T">The generic data model returned from the response</typeparam>
    public class ResponseWrapper<T>
    {
        public bool Success { get; } 
        public T Data { get; } 
        public int StatusCode { get; }
        public string ErrorMessage { get; }

        /// <param name="success">The success status of the response</param>
        /// <param name="data">The data returned from the response</param>
        /// <param name="statusCode">The status code of the response</param>
        /// <param name="errorMessage">Optional error message - used when the request fails</param>
        public ResponseWrapper(bool success, T data, int statusCode, string errorMessage = null)
        {
            Success = success;
            Data = data;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    };
    
    /// <summary>
    /// A generic easy to use helper class for wrapping the content from a HTTP response.
    /// </summary>
    public class ResponseWrapper
    {
        public bool Success { get; }
        public int StatusCode { get; }
        public string ErrorMessage { get; }

        /// <param name="success">The success status of the response</param>
        /// <param name="statusCode">The status code of the response</param>
        /// <param name="errorMessage">Optional error message - used when the request fails</param>
        public ResponseWrapper(bool success, int statusCode, string errorMessage = null)
        {
            Success = success;
            StatusCode = statusCode;
            ErrorMessage = errorMessage;
        }
    };
}