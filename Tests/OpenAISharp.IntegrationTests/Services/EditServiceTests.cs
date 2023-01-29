using OpenAISharp.Edit;
using OpenAISharp.Edit.Requests;
using OpenAISharp.Utilities.Constants;

namespace OpenAISharp.IntegrationTests.Services
{
    public class EditServiceTests
    {
        [Theory]
        [InlineData(KnownModelNames.TextDavinciEdit001)]
        [InlineData(KnownModelNames.CodeDavinciEdit001)]
        public async Task WhenCallingCreateEditAsyncShouldNotBeNull(string knownSupportedModel)
        {
            var service = IntegrationTestStartup.GetService<IEditService>();
            var response = await service.CreateEditAsync(new CreateEditRequest(knownSupportedModel, "Translate this to Spanish") { Input = "Hey" });
            Assert.NotNull(response);
        }
    }
}