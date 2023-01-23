using OpenAISharp.Embedding.Requests;
using OpenAISharp.Embedding.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Embedding
{
    /// <summary>
    /// Get a vector representation of a given input that can be easily consumed by machine learning models and algorithms.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/embeddings</remarks>
    public interface IEmbeddingService
    {
        /// <summary>
        /// Creates an embedding vector representing the input text.
        /// </summary>
        /// <returns>CreateEmbeddingResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/embeddings</remarks>
        Task<CreateEmbeddingResponse> CreateEmbeddingAsync(CreateEmbeddingRequest request);
    }
}

