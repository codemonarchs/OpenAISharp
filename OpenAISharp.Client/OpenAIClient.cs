using OpenAISharp.Client.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAISharp.Client
{
    /// <inheritdoc cref="IOpenAIClient"/>
    public class OpenAIClient : IOpenAIClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="httpClient"></param>
        public OpenAIClient(HttpClient httpClient) { _httpClient = httpClient; }

        /// <inheritdoc cref="IOpenAIClient.DeleteAsync"/>
        public async Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : class
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Delete, path));

        /// <inheritdoc cref="IOpenAIClient.GetAsync"/>
        public async Task<TResponse> GetAsync<TResponse>(string path) where TResponse : class
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Get, path));

        /// <inheritdoc cref="IOpenAIClient.GetStringAsync"/>
        public async Task<string> GetStringAsync(string path)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, path);
            var response = await _httpClient.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(content))
                return content;
            throw new OpenAIClientException(response.StatusCode, content);
        }

        /// <inheritdoc cref="IOpenAIClient.GetWithQueryParametersAsync"/>
        public async Task<TResponse> GetWithQueryParametersAsync<TResponse>(string path, Dictionary<string, object>? parameters = null) where TResponse : class
            => await GetAsync<TResponse>(parameters?.Count > 0 ? $"{path}?{string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}"))}" : path);

        /// <inheritdoc cref="IOpenAIClient.MultiPartFormPostAsync"/>
        public async Task<TResponse> MultiPartFormPostAsync<TResponse>(string path, MultipartFormDataContent formData) where TResponse : class
        {
            var response = await _httpClient.PostAsync(path, formData);
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                if (contentStream != null)
                {
                    var result = await JsonSerializer.DeserializeAsync<TResponse>(contentStream);
                    if (result != null)
                        return result;
                }
            }
            throw new OpenAIClientException(response.StatusCode, await response.Content.ReadAsStringAsync());
        }

        /// <inheritdoc cref="IOpenAIClient.PostAsync"/>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request) where TRequest : class where TResponse : class
                => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Post, path) { Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json) });

        /// <inheritdoc cref="IOpenAIClient.PostEmptyBodyAsync"/>
        public async Task<TResponse> PostEmptyBodyAsync<TResponse>(string path) where TResponse : class
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Post, path) { Content = new StringContent(string.Empty, Encoding.UTF8, MediaTypeNames.Application.Json) });

        /// <summary>
        /// Sends any HttpRequestMessage to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpRequestMessage"></param>
        /// <returns></returns>
        private async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage httpRequestMessage) where TResponse : class
        {
            var response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                using var contentStream = await response.Content.ReadAsStreamAsync();
                if (contentStream != null)
                {
                    var result = await JsonSerializer.DeserializeAsync<TResponse>(contentStream);
                    if (result != null)
                        return result;
                }
            }
            throw new OpenAIClientException(response.StatusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
