using OpenAISharp.Completion.Requests;
using OpenAISharp.Completion.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Completion
{
    /// <summary>
    /// Given a prompt, the model will return one or more predicted completions, and can also return the probabilities of alternative tokens at each position.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/completions</remarks>
    public interface ICompletionService
    {
        /// <summary>
        /// Creates a completion for the provided prompt and parameters
        /// </summary>
        /// <returns>CreateCompletionResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/completions</remarks>
        Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest request);
    }
}

