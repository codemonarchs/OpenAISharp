using OpenAISharp.Image;
using OpenAISharp.Image.Requests;

namespace OpenAISharp.IntegrationTests.Services
{
    public class ImageServiceTests
    {
        [Fact]
        public async Task WhenCallingCreateImageAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IImageService>();
            var response = await service.CreateImageAsync(new CreateImageRequest("Draw Etzio from Assassin's Creed"));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateImageEditAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IImageService>();
            var response = await service.CreateImageEditAsync(new CreateImageEditRequest("test_image_rgba.png", GetTestImagePath(), "Make me something random.", true));
            Assert.NotNull(response);
        }

        [Fact]
        public async Task WhenCallingCreateImageVariationAsyncShouldNotBeNull()
        {
            var service = IntegrationTestStartup.GetService<IImageService>();
            var response = await service.CreateImageVariationAsync(new CreateImageVariationRequest("test_image_rgba.png", GetTestImagePath(), true));
            Assert.NotNull(response);
        }

        private string GetTestImagePath() => Path.Combine(Directory.GetCurrentDirectory(), "TestFiles", "test_image_rgba.png");
    }
}