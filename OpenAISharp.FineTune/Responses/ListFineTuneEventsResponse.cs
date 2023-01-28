using OpenAISharp.FineTune.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Responses
{
    /// <remarks>Returned from <see cref="IFineTuneService.ListFineTuneEventsAsync"/>.</remarks>
    public class ListFineTuneEventsResponse
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("data")]
        public List<FineTuneEvent>? Data { get; set; }
    }
}

