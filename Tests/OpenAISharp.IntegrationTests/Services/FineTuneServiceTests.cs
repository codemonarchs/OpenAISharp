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
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.ListFineTunesAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateFineTuneAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.CreateFineTuneAsync(new CreateFineTuneRequest(""));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingRetrieveFineTuneAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.RetrieveFineTuneAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCancelFineTuneAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.CancelFineTuneAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingDeleteFineTuneModelAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.DeleteFineTuneModelAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingListFineTuneEventsAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.ListFineTuneEventsAsync("");
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingListFineTuneEventsAsyncWithStreamToFalseShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            var response = await service.ListFineTuneEventsAsync("", false);
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingListFineTuneEventsAsyncWithStreamToTrueShouldThrowNotImplementedException()
        {
            var service = IntegrationTestStartup.GetService<IFineTuneService>();
            await Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                var response = await service.ListFineTuneEventsAsync("", true);
            });
        }
    }
}
