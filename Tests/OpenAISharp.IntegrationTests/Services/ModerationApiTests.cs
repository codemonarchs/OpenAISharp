using OpenAISharp.Moderation;
using OpenAISharp.Moderation.Requests;

namespace OpenAISharp.IntegrationTests.Services
{
    public class ModerationServiceTests
    {
        [Fact]
        public async Task WhenCallingCreateModerationAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IModerationService>();
            var response = await service.CreateModerationAsync(new CreateModerationRequest("test"));
            Assert.NotNull(response);
        }
    }
}