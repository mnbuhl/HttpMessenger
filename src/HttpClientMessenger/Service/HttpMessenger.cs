using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using HttpClientMessenger.Extensions;
using HttpClientMessenger.Helpers;

namespace HttpClientMessenger.Service
{
    public class HttpMessenger : IHttpMessenger
    {
        public JsonSerializerOptions JsonOptions { get; set; } = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };
        private readonly HttpClient _client;

        public HttpMessenger(HttpClient client)
        {
            _client = client;
        }

        public async Task<ResponseWrapper<T>> Get<T>(string url, object queryParams = null)
        {
            string query = string.Empty;
            
            if (queryParams != null)
            {
                query = QueryParameterParser.GetQueryString(queryParams);
            }

            var response = await _client.GetAsync(url + query);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<T>(response);

            var data = await response.Content.ReadFromJsonAsync<T>(JsonOptions);

            return new ResponseWrapper<T>(true, data, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper<TResponse>> Post<T, TResponse>(string url, T data)
        {
            var response = await _client.PostAsJsonAsync(url, data, JsonOptions);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);

            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> Post<T>(string url, T data)
        {
            var response = await _client.PostAsJsonAsync(url, data, JsonOptions);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper<TResponse>> PostAsFormData<T, TResponse>(string url, T data) where T : HttpContent
        {
            var response = await _client.PostAsync(url, data);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);

            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> PostAsFormData<T>(string url, T data) where T : HttpContent
        {
            var response = await _client.PostAsync(url, data);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> Put<T>(string url, T data)
        {
            var response = await _client.PutAsJsonAsync(url, data, JsonOptions);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper<TResponse>> Put<T, TResponse>(string url, T data)
        {
            var response = await _client.PutAsJsonAsync(url, data, JsonOptions);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);
            
            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper<TResponse>> PutAsFormData<T, TResponse>(string url, T data) where T : HttpContent
        {
            var response = await _client.PutAsync(url, data);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);
            
            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> PutAsFormData<T>(string url, T data) where T : HttpContent
        {
            var response = await _client.PutAsync(url, data);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> Patch<T>(string url, T data)
        {
            var response = await _client.PatchAsJsonAsync(url, data, JsonOptions);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper<TResponse>> Patch<T, TResponse>(string url, T data)
        {
            var response = await _client.PatchAsJsonAsync(url, data, JsonOptions);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);
            
            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper<TResponse>> PatchAsFormData<T, TResponse>(string url, T data) where T : HttpContent
        {
            var response = await _client.PatchAsync(url, data);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);
            
            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> PatchAsFormData<T>(string url, T data) where T : HttpContent
        {
            var response = await _client.PatchAsync(url, data);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }

        public async Task<ResponseWrapper> Delete(string url)
        {
            var response = await _client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse(response);

            return new ResponseWrapper(true, (int)response.StatusCode);
        }
        
        public async Task<ResponseWrapper<TResponse>> Delete<TResponse>(string url)
        {
            var response = await _client.DeleteAsync(url);

            if (!response.IsSuccessStatusCode)
                return await GetErrorResponse<TResponse>(response);
            
            var dataResponse = await response.Content.ReadFromJsonAsync<TResponse>(JsonOptions);

            return new ResponseWrapper<TResponse>(true, dataResponse, (int)response.StatusCode);
        }

        private static async Task<ResponseWrapper<T>> GetErrorResponse<T>(HttpResponseMessage response)
        {
            string errorMessage = await response.Content.ReadAsStringAsync();
            return new ResponseWrapper<T>(false, default, (int)response.StatusCode, errorMessage);
        }
        
        private static async Task<ResponseWrapper> GetErrorResponse(HttpResponseMessage response)
        {
            string errorMessage = await response.Content.ReadAsStringAsync();
            return new ResponseWrapper(false, (int)response.StatusCode, errorMessage);
        }
    }
}