using OpenAISharp.Moderation.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IModerationService.CreateModerationAsync"/>.</remarks>
    public class CreateModerationResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("results")]
        public List<ModerationResult>? Results { get; set; }
    }
}

