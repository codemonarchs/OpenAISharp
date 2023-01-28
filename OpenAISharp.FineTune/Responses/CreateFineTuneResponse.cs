using OpenAISharp.FineTune.Models;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OpenAISharp.FineTune.Responses
{
    /// <remarks>Returned from <see cref="IFineTuneService.CreateFineTuneAsync"/>.</remarks>
    public class CreateFineTuneResponse
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("model")]
        public string? Model { get; set; }

        [JsonPropertyName("created_at")]
        public int? CreatedAt { get; set; }

        [JsonPropertyName("events")]
        public List<FineTuneEvent>? Events { get; set; }

        [JsonPropertyName("fine_tuned_model")]
        public string? FineTunedModel { get; set; }

        [JsonPropertyName("hyperparams")]
        public FineTuneHyperparams? Hyperparams { get; set; }

        [JsonPropertyName("organization_id")]
        public string? OrganizationId { get; set; }

        [JsonPropertyName("result_files")]
        public List<FineTuneResultFile>? ResultFiles { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("validation_files")]
        public List<FineTuneValidationFile>? ValidationFiles { get; set; }

        [JsonPropertyName("training_files")]
        public List<FineTuneTrainingFile>? TrainingFiles { get; set; }

        [JsonPropertyName("updated_at")]
        public int? UpdatedAt { get; set; }
    }
}

