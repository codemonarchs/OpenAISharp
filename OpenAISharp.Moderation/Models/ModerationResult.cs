using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class ModerationResult
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("categories")]
        public ModerationCategories? Categories { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("category_scores")]
        public ModerationCategoryScores? CategoryScores { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("flagged")]
        public bool? Flagged { get; set; }
    }
}

