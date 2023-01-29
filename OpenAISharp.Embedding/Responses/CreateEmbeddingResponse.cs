using OpenAISharp.Embedding.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Embedding.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IEmbeddingService.CreateEmbeddingAsync"/>.</remarks>
    public class CreateEmbeddingResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("data")]
        public List<EmbeddingData?>? Data { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("usage")]
        public EmbeddingUsage? Usage { get; set; }
    }
}

