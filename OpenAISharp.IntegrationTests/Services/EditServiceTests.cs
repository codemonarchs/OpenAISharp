using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
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
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IEditService>();
            var response = await service.CreateEditAsync(new CreateEditRequest(knownSupportedModel, "Translate this to Spanish") { Input = "Hey" });
            Assert.NotNull(response);
        }
    }
}