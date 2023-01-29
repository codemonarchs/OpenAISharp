using OpenAISharp.Model;
using OpenAISharp.Utilities.Constants;

namespace OpenAISharp.IntegrationTests.Services
{
    public class ModelServiceTests
    {
        [Fact]
        public async Task WhenCallingListModelsAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IModelService>();
            var response = await service.ListModelsAsync();
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingRetrieveModelAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IModelService>();
            var response = await service.RetrieveModelAsync(KnownModelNames.Ada);
            Assert.NotNull(response);
        }
    }
}