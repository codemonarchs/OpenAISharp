using OpenAISharp.Completion.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Completion.Responses
{
    /// <remarks>Returned from <see cref="ICompletionService.CreateCompletionAsync"/>.</remarks>
    public class CreateCompletionResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("choices")]
        public List<CompletionChoice>? Choices { get; set; }

        [JsonPropertyName("usage")]
        public CompletionUsage? Usage { get; set; }
    }
}
