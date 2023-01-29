using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class FineTuneHyperparams
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("batch_size")]
        public int? BatchSize { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("learning_rate_multiplier")]
        public double? LearningRateMultiplier { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("n_epochs")]
        public int? NEpochs { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("prompt_loss_weight")]
        public double? PromptLossWeight { get; set; }
    }
}

