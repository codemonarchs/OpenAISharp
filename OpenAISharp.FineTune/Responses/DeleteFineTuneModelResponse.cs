using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IFineTuneService.DeleteFineTuneModelAsync"/>.</remarks>
    public class DeleteFineTuneModelResponse
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
        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }
    }
}

