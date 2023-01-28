using OpenAISharp.Moderation.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Responses
{
    /// <remarks>Returned from <see cref="IModerationService.CreateModerationAsync"/>.</remarks>
    public class CreateModerationResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("results")]
        public List<ModerationResult>? Results { get; set; }
    }
}

