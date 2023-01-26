using OpenAISharp.Completion.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Completion
{
    public class CreateCompletionRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateCompletionRequest("mymodel");

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"mymodel\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateCompletionRequest("mymodel")
            {
                BestOf = null,
                Echo = null,
                FrequencyPenalty = null,
                LogitBias = null,
                Logprobs = null,
                MaxTokens = null,
                N = null,
                PresencePenalty = null,
                Prompt = null,
                Stop = null,
                Stream = null,
                Suffix = null,
                Temperature = null,
                TopP = null,
                User = null
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"mymodel\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateCompletionRequest("mymodel")
            {
                BestOf = 1,
                Echo = true,
                FrequencyPenalty = 1.0,
                LogitBias = "{\"50256\": -100}",
                Logprobs = 5,
                MaxTokens = 100,
                N = 2,
                PresencePenalty = 1.0,
                Prompt = "myprompt",
                Stop = 3,
                Stream = true,
                Suffix = "my suffix",
                Temperature = 0.9,
                TopP = 0.1,
                User = "user"
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"mymodel\",\"prompt\":\"myprompt\",\"suffix\":\"my suffix\",\"max_tokens\":100,\"temperature\":0.9,\"top_p\":0.1,\"n\":2,\"stream\":true,\"logprobs\":5,\"echo\":true,\"stop\":3,\"presence_penalty\":1,\"frequency_penalty\":1,\"best_of\":1,\"logit_bias\":\"{\\u002250256\\u0022: -100}\",\"user\":\"user\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
