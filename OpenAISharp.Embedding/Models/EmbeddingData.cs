using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Embedding.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class EmbeddingData
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("embedding")]
        public List<double>? Embedding { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("index")]
        public int? Index { get; set; }
    }
}

