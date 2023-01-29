using OpenAISharp.Edit.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Edit.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IEditService.CreateEditAsync"/>.</remarks>
    public class CreateEditResponse
    {
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
        [JsonPropertyName("choices")]
        public List<EditChoice?>? Choices { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("usage")]
        public EditUsage? Usage { get; set; }
    }
}

