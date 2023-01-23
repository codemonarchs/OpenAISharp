using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAISharp.Moderation.Requests
{
    public class CreateModerationRequest
    {
        /// <summary>
        /// The input text to classify.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/moderations/create#moderations/create-input</remarks>
        [JsonPropertyName("input")]
        [Required]
        public string? Input { get; set; }

        /// <summary>
        /// Two content moderations models are available: text-moderation-stable and text-moderation-latest.
        /// The default is text-moderation-latest which will be automatically upgraded over time.This ensures you are always using our most accurate model. 
        /// If you use text-moderation-stable, we will provide advanced notice before updating the model.Accuracy of text-moderation-stable may be slightly lower than for text-moderation-latest.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/moderations/create#moderations/create-model</remarks>
        [JsonPropertyName("model")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Model { get; set; }
    }
}

