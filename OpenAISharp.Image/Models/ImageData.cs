using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Models
{
    public class ImageData
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}

