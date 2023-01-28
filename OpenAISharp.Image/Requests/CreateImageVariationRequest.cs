using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Requests
{
    /// <summary>
    /// Creates a variation of a given image.
    /// </summary>
    /// <remarks>Used with <see cref="IImageService.CreateImageVariationAsync"/>.</remarks>
    public class CreateImageVariationRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imagePath"></param>
        /// <param name="useImageFilePath"></param>
        public CreateImageVariationRequest(string image, string imagePath, bool useImageFilePath)
        {
            Image = image;
            ImageContent = imagePath;
            UseImageFilePath = useImageFilePath;
        }

        /// <summary>
        /// The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB, and square.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-variation#images/create-variation-image</remarks>
        [JsonPropertyName("image")]
        public string Image { get; set; }

        /// <summary>
        /// The number of images to generate. Must be between 1 and 10.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-variation#images/create-variation-n</remarks>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-variation#images/create-variation-size</remarks>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-variation#images/create-variation-response_format</remarks>
        [JsonPropertyName("response_format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResponseFormat { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-variation#images/create-variation-user</remarks>
        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }

        /// <summary>
        /// The actual image content or a path to the image file.
        /// </summary>
        [JsonIgnore]
        public string ImageContent { get; }

        /// <summary>
        /// A flag to determine whether to get image data from a file path or if the data is already included.
        /// </summary>
        [JsonIgnore]
        public bool UseImageFilePath { get; }
    }
}

