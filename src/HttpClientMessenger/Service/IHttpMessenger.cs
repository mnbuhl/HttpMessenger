using System.Net.Http;
using System.Threading.Tasks;
using HttpClientMessenger.Helpers;

namespace HttpClientMessenger.Service
{
    public interface IHttpMessenger
    {
        /// <summary>
        /// Creates a GET request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="queryParams">String or anonymous object of the query parameters you want to pass</param>
        /// <typeparam name="T">The data model you wish to receive</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Get&lt;Product&gt;("products/1");</code></example>
        /// <example><code>await HttpMessenger.Get&lt;List&lt;Product&gt;&gt;("products");</code></example>
        Task<ResponseWrapper<T>> Get<T>(string url, object queryParams = null);

        /// <summary>
        /// Creates a POST request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Post&lt;CreateProductDto, ProductDto&gt;("products", product);</code></example>
        Task<ResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data);

        /// <summary>
        /// Creates a POST request to the specified url with the specified data, but does not return any data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Post&lt;CreateProductDto&gt;("products", product);</code></example>
        Task<ResponseWrapper> Post<T>(string url, T data);
        
        /// <summary>
        /// Creates a POST request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request. Typically MultipartFormDataContent or FormUrlEncodedContent, but supports all HttpContent children</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Post&lt;CreateProductDto, ProductDto&gt;("products", product);</code></example>
        Task<ResponseWrapper<TResponse>> PostAsFormData<T, TResponse>(string url, T data) where T : HttpContent;
        
        /// <summary>
        /// Creates a POST request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request. Typically MultipartFormDataContent or FormUrlEncodedContent, but supports all HttpContent children</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Post&lt;CreateProductDto, ProductDto&gt;("products", product);</code></example>
        Task<ResponseWrapper> PostAsFormData<T>(string url, T data) where T : HttpContent;

        /// <summary>
        /// Creates a PUT request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper> Put<T>(string url, T data);

        /// <summary>
        /// Creates a PUT request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/>with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto, ProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data);
        
        /// <summary>
        /// Creates a PUT request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request. Typically MultipartFormDataContent or FormUrlEncodedContent, but supports all HttpContent children</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto, ProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper<TResponse>> PutAsFormData<T, TResponse>(string url, T data) where T : HttpContent;
        
        /// <summary>
        /// Creates a PUT request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request. Typically MultipartFormDataContent or FormUrlEncodedContent, but supports all HttpContent children</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto, ProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper> PutAsFormData<T>(string url, T data) where T : HttpContent;

        /// <summary>
        /// Creates a PATCH request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Patch&lt;UpdateProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper> Patch<T>(string url, T data);
        
        /// <summary>
        /// Creates a PATCH request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto, ProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper<TResponse>> Patch<T, TResponse>(string url, T data);
        
        /// <summary>
        /// Creates a PATCH request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request. Typically MultipartFormDataContent or FormUrlEncodedContent, but supports all HttpContent children</typeparam>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto, ProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper<TResponse>> PatchAsFormData<T, TResponse>(string url, T data) where T : HttpContent;
        
        /// <summary>
        /// Creates a PATCH request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <param name="data">The data that is sent with the request</param>
        /// <typeparam name="T">The type of data that is sent with the request. Typically MultipartFormDataContent or FormUrlEncodedContent, but supports all HttpContent children</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/> with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Put&lt;UpdateProductDto, ProductDto&gt;("products/1", product);</code></example>
        Task<ResponseWrapper> PatchAsFormData<T>(string url, T data) where T : HttpContent;

        /// <summary>
        /// Creates a DELETE request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <returns>A <see cref="ResponseWrapper"/>with the success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Delete("products/1");</code></example>
        Task<ResponseWrapper> Delete(string url);
        
        /// <summary>
        /// Creates a DELETE request to the specified url with the specified data.
        /// </summary>
        /// <param name="url">The endpoint to where the request should be made</param>
        /// <typeparam name="TResponse">The type of the expected data to be returned from the request</typeparam>
        /// <returns>A <see cref="ResponseWrapper"/>with the data, success status, status code and error message if any</returns>
        /// <example><code>await HttpMessenger.Delete&lt;ProductDto&gt;("products/1");</code></example>
        Task<ResponseWrapper<TResponse>> Delete<TResponse>(string url);
    }
}