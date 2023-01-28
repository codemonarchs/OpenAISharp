using OpenAISharp.FineTune.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Responses
{
    /// <remarks>Returned from <see cref="IFineTuneService.ListFineTunesAsync"/>.</remarks>
    public class ListFineTunesResponse
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("data")]
        public List<FineTuneData>? Data { get; set; }
    }
}

