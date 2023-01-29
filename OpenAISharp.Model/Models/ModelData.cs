using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Model.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class ModelData
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
        public IEnumerable<ModelPermission>? Permission { get; set; }
    }
}
