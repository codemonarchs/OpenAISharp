using OpenAISharp.Client;
using OpenAISharp.Completion.Requests;
using OpenAISharp.Completion.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Completion
{
    /// <inheritdoc cref="ICompletionService"/>
    public class CompletionService : ICompletionService
    {
        private readonly IOpenAIClient _openAIClient;
        public CompletionService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <summary>
        /// Creates a completion for the provided prompt and parameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <remarks>POST https://api.openai.com/v1/completions</remarks>
        public async Task<CreateCompletionResponse> CreateCompletionAsync(CreateCompletionRequest request)
            => await _openAIClient.PostAsync<CreateCompletionRequest, CreateCompletionResponse>("/completions", request);
    }
}

