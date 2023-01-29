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
            var service = IntegrationTestStartup.GetService<ICompletionService>();
            var response = await service.CreateCompletionAsync(new CreateCompletionRequest(KnownModelNames.Ada));
            Assert.NotNull(response);
        }
    }
}