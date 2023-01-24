using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAISharp.Client
{
    public interface IOpenAIClient
    {
        /// <summary>
        /// Sends a generic GET request to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<TResponse> GetAsync<TResponse>(string uri) where TResponse : class, new();

        /// <summary>
        /// Sends a generic POST request to the Open AI API.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="request"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest request)
            where TRequest : class, new()
            where TResponse : class, new();

        /// <summary>
        /// Sends a generic DELETE request to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<TResponse> DeleteAsync<TResponse>(string uri) where TResponse : class, new();

        /// <summary>
        /// Sends a GET request to the Open AI API and reads the response as a string?.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<string> GetStringAsync(string uri);

        /// <summary>
        /// Sends a POST request to the Open AI API with an empty body.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<TResponse> PostEmptyBodyAsync<TResponse>(string uri) where TResponse : class, new();

        /// <summary>
        /// Sends a GET request to the Open AI API with query parameters.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="uri"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<TResponse> GetWithQueryParametersAsync<TResponse>(string uri, Dictionary<string, object>? parameters = null) where TResponse : class, new();
    }
}
