using OpenAISharp.Edit.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Edit.Responses
{
    public class CreateEditResponse
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("choices")]
        public List<EditChoice>? Choices { get; set; }

        [JsonPropertyName("usage")]
        public EditUsage? Usage { get; set; }
    }
}

