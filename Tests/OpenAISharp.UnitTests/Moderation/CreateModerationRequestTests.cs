using OpenAISharp.Moderation.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.Moderation
{
    public class CreateModerationRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new CreateModerationRequest("This is a test input.");

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"input\":\"This is a test input.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new CreateModerationRequest("This is a test input.")
            {
                Model = null,
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"input\":\"This is a test input.\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_WithAllOptionalProperties_ShouldIncludeAllOptionalProperties()
        {
            var request = new CreateModerationRequest("This is a test input.")
            {
                Model = "model"
            };

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"input\":\"This is a test input.\",\"model\":\"model\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
