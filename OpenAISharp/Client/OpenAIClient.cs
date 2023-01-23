using Microsoft.Extensions.Options;
using OpenAISharp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace OpenAISharp.Client
{
    /// <inheritdoc cref="IOpenAIClient"/>
    public class OpenAIClient : IOpenAIClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<OpenAIClientOptions> _options;
        private readonly string? BaseUri = "https://api.openai.com/v1";

        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="httpClientFactory"></param>
        /// <param name="options"></param>
        public OpenAIClient(IHttpClientFactory httpClientFactory, IOptions<OpenAIClientOptions> options)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
        }

        /// <summary>
        /// Creates the HttpClient with the BaseUri, sets the Bearer token with the ApiKey, and sets the OpenAI-Organization header.
        /// </summary>
        /// <returns></returns>
        private HttpClient CreateClient()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _options.Value.ApiKey);
            client.DefaultRequestHeaders.Add("OpenAI-Organization", _options.Value.OrganizationId);
            return client;
        }

        /// <inheritdoc cref="IOpenAIClient.DeleteAsync"/>
        public async Task<TResponse> DeleteAsync<TResponse>(string uri) where TResponse : class, new()
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Delete, new Uri(uri)));

        /// <inheritdoc cref="IOpenAIClient.GetAsync"/>
        public async Task<TResponse> GetAsync<TResponse>(string uri) where TResponse : class, new()
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Get, new Uri(uri)));

        /// <inheritdoc cref="IOpenAIClient.GetStringAsync"/>
        public async Task<string> GetStringAsync(string uri)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, new Uri(uri));
            var client = CreateClient();
            var response = await client.SendAsync(message);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(content))
                return content;
            throw new OpenAIClientException(response.StatusCode, content);
        }

        /// <inheritdoc cref="IOpenAIClient.GetWithQueryParametersAsync"/>
        public async Task<TResponse> GetWithQueryParametersAsync<TResponse>(string uri, Dictionary<string, object>? parameters = null) where TResponse : class, new()
            => await GetAsync<TResponse>(parameters?.Count > 0 ? $"{uri}?{HttpUtility.UrlEncode(string.Join("&", parameters.Select(kvp => $"{kvp.Key}={kvp.Value}")))}" : uri);

        /// <inheritdoc cref="IOpenAIClient.PostAsync"/>
        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request) where TRequest : class, new() where TResponse : class, new()
                => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Post, new Uri(uri)) { Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json) });

        /// <inheritdoc cref="IOpenAIClient.PostEmptyBodyAsync"/>
        public async Task<TResponse> PostEmptyBodyAsync<TResponse>(string uri) where TResponse : class, new()
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Post, new Uri(uri)) { Content = new StringContent(null, Encoding.UTF8, MediaTypeNames.Application.Json) });

        /// <summary>
        /// Sends any HttpRequestMessage to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpRequestMessage"></param>
        /// <returns></returns>
        private async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage httpRequestMessage) where TResponse : class, new()
        {
            var client = CreateClient();
            var response = await client.SendAsync(httpRequestMessage);
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
