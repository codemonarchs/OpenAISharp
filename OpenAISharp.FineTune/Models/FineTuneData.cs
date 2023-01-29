using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Models
{
    /// <summary>
    /// Description not provided by Open AI API.
    /// </summary>
    public class FineTuneData
    {
        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("model")]
        public string? Model { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("created_at")]
        public int? CreatedAt { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("fine_tuned_model")]
        public string? FineTunedModel { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("hyperparams")]
        public FineTuneHyperparams? Hyperparams { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("organization_id")]
        public string? OrganizationId { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("result_files")]
        public List<FineTuneResultFile>? ResultFiles { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("validation_files")]
        public List<FineTuneValidationFile>? ValidationFiles { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("training_files")]
        public List<FineTuneTrainingFile>? TrainingFiles { get; set; }

        /// <summary>
        /// Description not provided by Open AI API.
        /// </summary>
        [JsonPropertyName("updated_at")]
        public int? UpdatedAt { get; set; }
    }
}

