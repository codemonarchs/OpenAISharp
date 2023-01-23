using OpenAISharp.File.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.File.Responses
{
    public class ListFilesResponse
    {
        [JsonPropertyName("data")]
        public List<FileData> Data { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }
    }
}

