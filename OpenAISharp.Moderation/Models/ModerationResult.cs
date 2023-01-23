﻿using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Models
{
    public class ModerationResult
    {
        [JsonPropertyName("categories")]
        public ModerationCategories? Categories { get; set; }

        [JsonPropertyName("category_scores")]
        public ModerationCategoryScores? CategoryScores { get; set; }

        [JsonPropertyName("flagged")]
        public bool? Flagged { get; set; }
    }
}

