using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Completion;
using OpenAISharp.Completion.Requests;
using OpenAISharp.Utilities.Constants;

namespace OpenAISharp.IntegrationTests.Services
{
    public class CompletionServiceTests
    {
        [Fact]
        public async Task WhenCallingCreateCompletionAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<ICompletionService>();
            var response = await service.CreateCompletionAsync(new CreateCompletionRequest(KnownModelNames.Ada));
            Assert.NotNull(response);
        }
    }
}