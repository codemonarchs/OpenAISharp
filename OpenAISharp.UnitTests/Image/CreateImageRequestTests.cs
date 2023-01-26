using OpenAISharp.Image.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Image
{
    public class CreateImageRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateImageRequest("A prompt");

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"prompt\":\"A prompt\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateImageRequest("A prompt")
            {
                N = null,
                ResponseFormat = null,
                Size = null,
                User = null,
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"prompt\":\"A prompt\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateImageRequest("A prompt")
            {
                N = 2,
                ResponseFormat = "url",
                Size = "256x256",
                User = "user"
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"prompt\":\"A prompt\",\"n\":2,\"size\":\"256x256\",\"response_format\":\"url\",\"user\":\"user\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
