using OpenAISharp.Embedding.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Embedding
{
    public class CreateEmbeddingRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateEmbeddingRequest("text-davinci-002", "The sky is blue, the grass is green.");

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"text-davinci-002\",\"input\":\"The sky is blue, the grass is green.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateEmbeddingRequest("text-davinci-002", "The sky is blue, the grass is green.")
            {
                User = null
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"text-davinci-002\",\"input\":\"The sky is blue, the grass is green.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateEmbeddingRequest("text-davinci-002", "The sky is blue, the grass is green.")
            {
                User = "user",
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"model\":\"text-davinci-002\",\"input\":\"The sky is blue, the grass is green.\",\"user\":\"user\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
