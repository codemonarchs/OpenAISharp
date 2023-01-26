using OpenAISharp.File.Requests;
using System.Text.Json;

namespace OpenAISharp.UnitTests.File
{
    public class UploadFileRequestTests
    {
        [Fact]
        public void Serialize_WithAllRequiredProperties_ShouldIncludeAllRequiredProperties()
        {
            var request = new UploadFileRequest("myfile", "file content", false);

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"file\":\"myfile.jsonl\",\"purpose\":\"fine-tune\"}";

            Assert.Equal(expectedJson, json);
        }

        [Fact]
        public void Serialize_ExcludeAllOptionalProperties_ShouldNotIncludeOptionalProperties()
        {
            var request = new UploadFileRequest("myfile", null, false);

            var json = JsonSerializer.Serialize(request);

            var expectedJson = "{\"file\":\"myfile.jsonl\",\"purpose\":\"fine-tune\"}";

            Assert.Equal(expectedJson, json);
        }
    }
}
