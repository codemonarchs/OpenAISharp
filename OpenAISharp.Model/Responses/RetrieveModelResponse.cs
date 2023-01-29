using OpenAISharp.Model.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Model.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IModelService.RetrieveModelAsync"/>.</remarks>
    public class RetrieveModelResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("owned_by")]
        public string? OwnedBy { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("permission")]
        public List<ModelPermission?>? Permission { get; set; }
    }
}
