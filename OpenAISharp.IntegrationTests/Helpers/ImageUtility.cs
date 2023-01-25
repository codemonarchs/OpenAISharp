using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace OpenAISharp.IntegrationTests.Helpers
{
    public class ImageUtility
    {
        /// <summary>
        /// Creates a blank image for testing.
        /// </summary>
        /// <param name="path"></param>
        public static void CreateTransparentRGBAImage(string path)
        {
            using Image<Rgba32> image = new(400, 400);
            var width = image.Width;
            var height = image.Height;
            var pixelData = new Rgba32[width * height];
            for (int i = 0; i < pixelData.Length; i++)
                pixelData[i] = Color.Transparent;
            image.Save(path);
        }
    }
}
