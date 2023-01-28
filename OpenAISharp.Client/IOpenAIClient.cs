using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenAISharp.Client
{
    /// <summary>
    /// Typed client containing generic HTTP request methods for interfacing with the Open AI API.
    /// </summary>
    public interface IOpenAIClient
    {
        /// <summary>
        /// Sends a generic GET request to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<TResponse> GetAsync<TResponse>(string path) where TResponse : class;

        /// <summary>
        /// Sends a generic POST request to the Open AI API.
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="path"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<TResponse> PostAsync<TRequest, TResponse>(string path, TRequest request) where TRequest : class where TResponse : class;

        /// <summary>
        /// Sends a generic DELETE request to the Open AI API.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<TResponse> DeleteAsync<TResponse>(string path) where TResponse : class;

        /// <summary>
        /// Sends a GET request to the Open AI API and reads the response as a string?.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<string> GetStringAsync(string path);

        /// <summary>
        /// Sends a POST request to the Open AI API with an empty body.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        Task<TResponse> PostEmptyBodyAsync<TResponse>(string path) where TResponse : class;

        /// <summary>
        /// Sends a GET request to the Open AI API with query parameters.
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="path"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        Task<TResponse> GetWithQueryParametersAsync<TResponse>(string path, Dictionary<string, object>? parameters = null) where TResponse : class;

        /// <summary>
        /// Sends a multi part form POST request to the Open AI API. 
        /// </summary>
        /// <typeparam name="TResponse"></typeparam>
        /// <param name="path"></param>
        /// <param name="formData"></param>
        /// <returns></returns>
        Task<TResponse> MultiPartFormPostAsync<TResponse>(string path, MultipartFormDataContent formData) where TResponse : class;
    }
}
