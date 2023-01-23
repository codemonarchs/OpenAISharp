using OpenAISharp.Constants;
using OpenAISharp.Model.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Model
{
    /// <summary>
    /// List and describe the various models available in the API. You can refer to the Models documentation to understand what models are available and the differences between them.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/models</remarks>
    public interface IModelService
    {
        /// <summary>
        /// Lists the currently available models, and provides basic information about each one such as the owner and availability.
        /// </summary>
        /// <returns>ListModelsResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/models</remarks>
        Task<ListModelsResponse> ListModelsAsync();

        /// <summary>
        /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
        /// </summary>
        /// <param name="model">The ID of the model to use for this request.</param>
        /// <returns>RetrieveModelsResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/models/{model}</remarks>
        Task<RetrieveModelResponse> RetrieveModelAsync(string model);

        /// <inheritdoc cref="IModelService.RetrieveModelAsync"/>
        Task<RetrieveModelResponse> RetrieveModelAsync(DefaultModels model);
    }
}

