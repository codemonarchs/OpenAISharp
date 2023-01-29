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
            var service = IntegrationTestStartup.GetService<IEmbeddingService>();
            var input = "test";
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithStringArrayShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IEmbeddingService>(); ;
            var input = new string[] { "test", "test2" };
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithTokenArrayShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IEmbeddingService>();
            var input = new int[] { 1, 2, 3 };
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateEmbeddingAsyncWithArrayOfTokenArraysShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IEmbeddingService>();
            var input = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 } };
            var response = await service.CreateEmbeddingAsync(new CreateEmbeddingRequest(KnownModelNames.TextEmbeddingAda002, input));
            Assert.NotNull(response);
        }
    }
}