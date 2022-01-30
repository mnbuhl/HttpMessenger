using System.Threading.Tasks;
using HttpService.Helpers;

namespace HttpService.Service
{
    public interface IHttpService
    {
        /// <summary>
        /// Creates a GET request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <typeparam name="T">The data model you wish to receive</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpService.Get&lt;Product&gt;("products/1");</code></example>
        /// <example><code>await HttpService.Get&lt;List&lt;Product&gt;&gt;("products");</code></example>
        Task<ResponseWrapper<T>> Get<T>(string url);

        /// <summary>
        /// Creates a POST request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpService.Post&lt;CreateProductDto, ProductDto&gt;("products", product);</code></example>
        Task<ResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);

        /// <summary>
        /// Creates a POST request to the specified url with the specified data, but does not return any data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpService.Post&lt;CreateProductDto&gt;("products", product);</code></example>
        Task<ResponseWrapper> Post<T>(string url, T data);

        /// <summary>
        /// Creates a PUT request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpService.Put&lt;UpdateProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper> Put<T>(string url, T data);

        /// <summary>
        /// Creates a PATCH request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpService.Patch&lt;UpdateProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper> Patch<T>(string url, T data);

        /// <summary>
        /// Creates a DELETE request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpService.Delete("products/1");</code></example>
        Task<ResponseWrapper> Delete(string url);
    }
}