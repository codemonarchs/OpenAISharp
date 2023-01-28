using OpenAISharp.Model.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Model.Responses
{
    /// <remarks>Returned from <see cref="IModelService.ListModelsAsync"/>.</remarks>
    public class ListModelsResponse
    {
        [JsonPropertyName("data")]
        public List<ModelData>? Data { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }
    }
}
