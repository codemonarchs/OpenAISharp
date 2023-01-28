using OpenAISharp.Embedding.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Embedding.Responses
{
    /// <remarks>Returned from <see cref="IEmbeddingService.CreateEmbeddingAsync"/>.</remarks>
    public class CreateEmbeddingResponse
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("data")]
        public List<EmbeddingData?>? Data { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("usage")]
        public EmbeddingUsage? Usage { get; set; }
    }
}

