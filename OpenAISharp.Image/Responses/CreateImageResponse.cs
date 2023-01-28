using OpenAISharp.Image.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Responses
{
    /// <remarks>Returned from <see cref="IImageService.CreateImageAsync"/>.</remarks>
    public class CreateImageResponse
    {
        [JsonPropertyName("created")]
        public int? Created { get; set; }

        [JsonPropertyName("data")]
        public List<ImageData>? Data { get; set; }
    }
}

