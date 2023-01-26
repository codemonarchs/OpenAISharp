using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Image;
using OpenAISharp.Image.Requests;

namespace OpenAISharp.IntegrationTests.Services
{
    public class ImageServiceTests
    {
        [Fact]
        public async Task WhenCallingCreateImageAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IImageService>();
            var response = await service.CreateImageAsync(new CreateImageRequest("Draw Etzio from Assassin's Creed"));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateImageEditAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IImageService>();
            var response = await service.CreateImageEditAsync(new CreateImageEditRequest("test_image_rgba.png", GetTestImagePath(), "Make me something random.", true));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateImageVariationAsyncShouldNotBeNull()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<IImageService>();
            var response = await service.CreateImageVariationAsync(new CreateImageVariationRequest("test_image_rgba.png", GetTestImagePath(), true));
            Assert.NotNull(response);
        }

        private string GetTestImagePath() => Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "test_image_rgba.png");
    }
}