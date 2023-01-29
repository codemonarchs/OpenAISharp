using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class ModerationCategoryScores
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("hate")]
        public double? Hate { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("hate/threatening")]
        public double? HateThreatening { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("self-harm")]
        public double? SelfHarm { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("sexual")]
        public double? Sexual { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("sexual/minors")]
        public double? SexualMinors { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("violence")]
        public double? Violence { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("violence/graphic")]
        public double? ViolenceGraphic { get; set; }
    }
}

