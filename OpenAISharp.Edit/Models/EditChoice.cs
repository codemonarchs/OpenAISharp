﻿using System.Text.Json.Serialization;

namespace OpenAISharp.Edit.Models
{
    public class EditChoice
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("index")]
        public int? Index { get; set; }

        [JsonPropertyName("logprobs")]
        public int? Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string? FinishReason { get; set; }
    }
}
