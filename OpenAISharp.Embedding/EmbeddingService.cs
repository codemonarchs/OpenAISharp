using OpenAISharp.Client;
using OpenAISharp.Embedding.Requests;
using OpenAISharp.Embedding.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Embedding
{
    /// <inheritdoc cref="IEmbeddingService"/>
    public class EmbeddingService : IEmbeddingService
    {
        private readonly IOpenAIClient _openAIClient;
        public EmbeddingService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IEmbeddingService.CreateEmbeddingAsync"/>
        public async Task<CreateEmbeddingResponse> CreateEmbeddingAsync(CreateEmbeddingRequest request)
            => await _openAIClient.PostAsync<CreateEmbeddingRequest, CreateEmbeddingResponse>("/embeddings", request);
    }
}

