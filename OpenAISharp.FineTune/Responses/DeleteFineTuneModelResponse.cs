﻿using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Responses
{
    public class DeleteFineTuneModelResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }
    }
}

