using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Embedding.Models
{
    public class EmbeddingData
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("embedding")]
        public List<double>? Embedding { get; set; }

        [JsonPropertyName("index")]
        public int? Index { get; set; }
    }
}

