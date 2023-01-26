using OpenAISharp.Edit.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Edit
{
    public class CreateCompletionRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateEditRequest("text-davinci-002", "Write a poem about nature.");

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"text-davinci-002\",\"instruction\":\"Write a poem about nature.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateEditRequest("text-davinci-002", "Write a poem about nature.")
            {
                Input = null,
                N = null,
                Temperature = null,
                TopP = null
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"text-davinci-002\",\"instruction\":\"Write a poem about nature.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateEditRequest("text-davinci-002", "Write a poem about nature.")
            {
                Input = "some input",
                N = 2,
                Temperature = 0.9,
                TopP = 0.1
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"text-davinci-002\",\"input\":\"some input\",\"instruction\":\"Write a poem about nature.\",\"n\":2,\"temperature\":0.9,\"top_p\":0.1}";

            Assert.Equal(expectedJson, json);
        }
    }
}
