using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Model;
using OpenAISharp.Utilities.Constants;

namespace OpenAISharp.IntegrationTests.Services
{
    public class ModelServiceTests
    {
        [Fact]
        public async Task WhenCallingListModelsAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IModelService>();
            var response = await service.ListModelsAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingRetrieveModelAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IModelService>();
            var response = await service.RetrieveModelAsync(KnownModelNames.Ada);
            Assert.NotNull(response);
        }
    }
}