using System.Text.Json.Serialization;

namespace OpenAISharp.Completion.Models
{
    public class CompletionChoice
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("index")]
        public int? Index { get; set; }

        [JsonPropertyName("logprobs")]
        public int? Logprobs { get; set; }

        [JsonPropertyName("finish_reason")]
        public string? FinishReason { get; set; }
    }
}
