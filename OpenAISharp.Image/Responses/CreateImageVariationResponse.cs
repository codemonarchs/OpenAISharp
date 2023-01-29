using OpenAISharp.Image.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IImageService.CreateImageVariationAsync"/>.</remarks>
    public class CreateImageVariationResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("created")]
        public int? Created { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("data")]
        public List<ImageData>? Data { get; set; }
    }
}

