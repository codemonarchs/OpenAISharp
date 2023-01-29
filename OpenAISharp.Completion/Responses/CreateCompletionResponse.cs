using OpenAISharp.Completion.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Completion.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="ICompletionService.CreateCompletionAsync"/>.</remarks>
    public class CreateCompletionResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("created")]
        public int? Created { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("choices")]
        public List<CompletionChoice>? Choices { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("usage")]
        public CompletionUsage? Usage { get; set; }
    }
}
