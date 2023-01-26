using OpenAISharp.Image.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Image
{
    public class CreateImageVariationRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateImageVariationRequest("image", "imagepath", false);

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"image\":\"image\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateImageVariationRequest("image", "imagepath", false)
            {
                N = null,
                Size = null,
                ResponseFormat = null,
                User = null,
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"image\":\"image\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateImageVariationRequest("image", "imagepath", false)
            {
                N = 2,
                ResponseFormat = "url",
                Size = "256x256",
                User = "user"
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"image\":\"image\",\"n\":2,\"size\":\"256x256\",\"response_format\":\"url\",\"user\":\"user\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
