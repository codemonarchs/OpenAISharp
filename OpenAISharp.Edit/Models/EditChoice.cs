﻿using System.Text.Json.Serialization;

namespace OpenAISharp.Edit.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class EditChoice
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("index")]
        public int? Index { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("logprobs")]
        public int? Logprobs { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("finish_reason")]
        public string? FinishReason { get; set; }
    }
}
