using OpenAISharp.Model.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Model.Responses
{
    public class RetrieveModelResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("owned_by")]
        public string? OwnedBy { get; set; }

        [JsonPropertyName("permission")]
        public List<ModelPermission?>? Permission { get; set; }
    }
}
