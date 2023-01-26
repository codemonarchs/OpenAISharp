using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.FineTune;
using OpenAISharp.FineTune.Requests;

namespace OpenAISharp.IntegrationTests.Services
{
    public class FineTuneServiceTests
    {
        [Fact]
        public async Task WhenCallingListFineTunesAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.ListFineTunesAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateFineTuneAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.CreateFineTuneAsync(new CreateFineTuneRequest(""));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingRetrieveFineTuneAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.RetrieveFineTuneAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCancelFineTuneAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.CancelFineTuneAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingDeleteFineTuneModelAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.DeleteFineTuneModelAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingListFineTuneEventsAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.ListFineTuneEventsAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingListFineTuneEventsAsyncWithStreamToFalseShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            var response = await service.ListFineTuneEventsAsync("", false);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingListFineTuneEventsAsyncWithStreamToTrueShouldThrowNotImplementedException()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IFineTuneService>();
            await Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                var response = await service.ListFineTuneEventsAsync("", true);
            });
        }
    }
}
