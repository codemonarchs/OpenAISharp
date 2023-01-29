using OpenAISharp.Model.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Model.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IModelService.ListModelsAsync"/>.</remarks>
    public class ListModelsResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("data")]
        public List<ModelData>? Data { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }
    }
}
