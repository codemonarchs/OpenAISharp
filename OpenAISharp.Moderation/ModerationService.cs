using OpenAISharp.Client;
using OpenAISharp.Moderation.Requests;
using OpenAISharp.Moderation.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Moderation
{
    /// <inheritdoc cref="IModerationService"/>
    public class ModerationService : IModerationService
    {
        private readonly IOpenAIClient _openAIClient;

        /// <inheritdoc cref="IModerationService"/>
        public ModerationService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IModerationService.CreateModerationAsync"/>
        public async Task<CreateModerationResponse> CreateModerationAsync(CreateModerationRequest request)
            => await _openAIClient.PostAsync<CreateModerationRequest, CreateModerationResponse>("/v1/moderations", request);
    }
}

