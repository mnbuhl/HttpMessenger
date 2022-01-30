using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace HttpService.Extensions;

public static class HttpClientExtensions
{
    public static Task<HttpResponseMessage> PatchAsJsonAsync<TValue>(this HttpClient client, string? requestUri,
        TValue value, JsonSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }

        JsonContent content = JsonContent.Create(value, mediaType: null, options);
        return client.PatchAsync(requestUri, content, cancellationToken);
    }
}