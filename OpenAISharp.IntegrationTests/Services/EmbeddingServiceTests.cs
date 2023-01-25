using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Embedding;
using OpenAISharp.Embedding.Requests;
using OpenAISharp.Utilities.Constants;

namespace OpenAISharp.IntegrationTests.Services
{
    public class EmbeddingServiceTests
    {
        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithStringShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IEmbeddingService>();
            var input = "test";
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithStringArrayShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IEmbeddingService>();
            var input = new string[] { "test", "test2" };
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithTokenArrayShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IEmbeddingService>();
            var input = new int[] { 1, 2, 3 };
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithArrayOfTokenArraysShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IEmbeddingService>();
            var input = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }
    }
}