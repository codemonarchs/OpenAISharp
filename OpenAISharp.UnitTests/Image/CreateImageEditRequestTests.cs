using OpenAISharp.Image.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Image
{
    public class CreateImageEditRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateImageEditRequest("image", "image.png", "Make a rainbow.", true);

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"image\":\"image\",\"prompt\":\"Make a rainbow.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateImageEditRequest("image", "image.png", "Make a rainbow.", true)
            {
                Mask = null,
                MaskContent = null,
                N = null,
                ResponseFormat = null,
                Size = null,
                User = null,
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"image\":\"image\",\"prompt\":\"Make a rainbow.\"}";

            Assert.Equal(expectedJson, json);
        }


        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateImageEditRequest("image", "image.png", "Make a rainbow.", true)
            {
                Mask = "mask",
                MaskContent = "maskcontent",
                N = 2,
                ResponseFormat = "url",
                Size = "256x256",
                UseMaskFilePath = true,
                User = "user"
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"image\":\"image\",\"mask\":\"mask\",\"prompt\":\"Make a rainbow.\",\"n\":2,\"size\":\"256x256\",\"response_format\":\"url\",\"user\":\"user\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
