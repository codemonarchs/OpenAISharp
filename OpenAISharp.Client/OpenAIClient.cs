using Microsoft.Extensions.Options;
using OpenAISharp.Client.Exceptions;
using OpenAISharp.Client.Options;
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

        /// <inheritdoc cref="IOpenAIClient.DeleteAsync"/>
        public async Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : class
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Delete, GetUrl(path)));

        /// <inheritdoc cref="IOpenAIClient.GetAsync"/>
        public async Task<TResponse> GetAsync<TResponse>(string path) where TResponse : class
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Get, GetUrl(path)));

        /// <inheritdoc cref="IOpenAIClient.GetStringAsync"/>
        public async Task<string> GetStringAsync(string path)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, GetUrl(path));
            var client = CreateClient();
            var response = await client.SendAsync(message);
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
            var client = CreateClient();
            var response = await client.PostAsync(GetUrl(path), formData);
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
                => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Post, GetUrl(path)) { Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json) });

        /// <inheritdoc cref="IOpenAIClient.PostEmptyBodyAsync"/>
        public async Task<TResponse> PostEmptyBodyAsync<TResponse>(string path) where TResponse : class
            => await SendAsync<TResponse>(new HttpRequestMessage(HttpMethod.Post, GetUrl(path)) { Content = new StringContent(string.Empty, Encoding.UTF8, MediaTypeNames.Application.Json) });

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

        /// <summary>
        /// Gets the URL used to hit the Open AI API.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetUrl(string path)
            => path.StartsWith("/") ? $"{BaseUri}{path}" : $"{BaseUri}/{path}";

        /// <summary>
        /// Sends any HttpRequestMessage to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="httpRequestMessage"></param>
        /// <returns></returns>
        private async Task<TResponse> SendAsync<TResponse>(HttpRequestMessage httpRequestMessage) where TResponse : class
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
