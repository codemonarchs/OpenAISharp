using System.Text.Json.Serialization;

namespace OpenAISharp.File.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IFileService.DeleteFileAsync"/>.</remarks>
    public class DeleteFileResponse
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

