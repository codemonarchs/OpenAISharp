using OpenAISharp.File.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.File.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IFileService.ListFilesAsync"/>.</remarks>
    public class ListFilesResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("data")]
        public List<FileData>? Data { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }
    }
}

