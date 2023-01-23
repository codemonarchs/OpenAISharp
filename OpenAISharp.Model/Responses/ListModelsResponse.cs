using OpenAISharp.Model.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Model.Responses
{
    public class ListModelsResponse
    {
        [JsonPropertyName("data")]
        public List<ModelData>? Data { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }
    }
}
