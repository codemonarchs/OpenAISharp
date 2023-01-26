using OpenAISharp.FineTune.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.FineTune
{
    public class CreateFineTuneRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateFineTuneRequest("myfile");

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"training_file\":\"myfile\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateFineTuneRequest("myfile")
            {
                ValidationFile = null,
                Model = null,
                NEpochs = null,
                BatchSize = null
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"training_file\":\"myfile\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateFineTuneRequest("myfile")
            {
                BatchSize = 1,
                ClassificationBetas = new List<object?>(),
                ClassificationNClasses = 1,
                ClassificationPositiveClass = "classificationpositiveclass",
                ComputeClassificationMetrics = true,
                LearningRateMultiplier = 1,
                Model = "model",
                NEpochs = 1,
                PromptWeightLoss = 1,
                Suffix = "suffix",
                ValidationFile = "validationfile",
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"training_file\":\"myfile\",\"validation_file\":\"validationfile\",\"model\":\"model\",\"n_epochs\":1,\"batch_size\":1,\"learning_rate_multiplier\":1,\"prompt_loss_weight\":1,\"compute_classification_metrics\":true,\"classification_n_classes\":1,\"classification_positive_class\":\"classificationpositiveclass\",\"classification_betas\":[],\"suffix\":\"suffix\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
