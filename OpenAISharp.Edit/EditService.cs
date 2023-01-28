using OpenAISharp.Client;
using OpenAISharp.Edit.Requests;
using OpenAISharp.Edit.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Edit
{
    /// <inheritdoc cref="IEditService"/>
    public class EditService : IEditService
    {
        private readonly IOpenAIClient _openAIClient;
        
        /// <inheritdoc cref="IEditService"/>
        public EditService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IEditService.CreateEditAsync"/>
        public async Task<CreateEditResponse> CreateEditAsync(CreateEditRequest request)
            => await _openAIClient.PostAsync<CreateEditRequest, CreateEditResponse>("/v1/edits", request);
    }
}

