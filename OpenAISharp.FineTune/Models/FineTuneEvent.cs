using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class FineTuneEvent
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("created_at")]
        public int? CreatedAt { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("level")]
        public string? Level { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("message")]
        public string? Message { get; set; }
    }
}

