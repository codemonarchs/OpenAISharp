using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Moderation;
using OpenAISharp.Moderation.Requests;

namespace OpenAISharp.IntegrationTests.Services
{
    public class ModerationServiceTests
    {
        [Fact]
        public async Task WhenCallingCreateModerationAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IModerationService>();
            var response = await service.CreateModerationAsync(new CreateModerationRequest("test"));
            Assert.NotNull(response);
        }
    }
}