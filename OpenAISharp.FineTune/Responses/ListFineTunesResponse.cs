using OpenAISharp.FineTune.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Responses
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    /// <remarks>Returned from <see cref="IFineTuneService.ListFineTunesAsync"/>.</remarks>
    public class ListFineTunesResponse
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("data")]
        public List<FineTuneData>? Data { get; set; }
    }
}

