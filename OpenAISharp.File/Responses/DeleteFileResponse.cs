using System.Text.Json.Serialization;

namespace OpenAISharp.File.Responses
{
    /// <remarks>Returned from <see cref="IFileService.DeleteFileAsync"/>.</remarks>
    public class DeleteFileResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("deleted")]
        public bool? Deleted { get; set; }
    }
}

