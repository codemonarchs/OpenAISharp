using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class ModerationCategories
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("hate")]
        public bool? Hate { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("hate/threatening")]
        public bool? HateThreatening { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("self-harm")]
        public bool? SelfHarm { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("sexual")]
        public bool? Sexual { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("sexual/minors")]
        public bool? SexualMinors { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("violence")]
        public bool? Violence { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("violence/graphic")]
        public bool? ViolenceGraphic { get; set; }
    }
}

