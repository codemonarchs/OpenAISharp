using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Requests
{
    /// <summary>
    /// Creates an edited or extended image given an original image and a prompt.
    /// </summary>
    public class CreateImageEditRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="imagePath"></param>
        /// <param name="prompt"></param>
        public CreateImageEditRequest(string image, string imagePath, string prompt, bool useImageFilePath)
        {
            Image = image;
            ImageContent = imagePath;
            Prompt = prompt;
            UseImageFilePath = useImageFilePath;
        }

        /// <summary>
        /// The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not provided, image must have transparency, which will be used as the mask.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-image</remarks>
        [JsonPropertyName("image")]
        public string Image { get; }

        /// <summary>
        /// An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited. Must be a valid PNG file, less than 4MB, and have the same dimensions as image.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-mask</remarks>
        [JsonPropertyName("mask")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Mask { get; set; }

        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-prompt</remarks>
        [JsonPropertyName("prompt")]
        public string Prompt { get; }

        /// <summary>
        /// The number of images to generate. Must be between 1 and 10.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-n</remarks>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-size</remarks>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-response_format</remarks>
        [JsonPropertyName("response_format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResponseFormat { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-user</remarks>
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

        /// <summary>
        /// The actual mask content or a path to the mask image file.
        /// </summary>
        [JsonIgnore]
        public string? MaskContent { get; set; }

        /// <summary>
        /// A flag to determine whether to get mask image data from a file path or if the data is already included.
        /// </summary>
        [JsonIgnore]
        public bool UseMaskFilePath { get; set; }
    }
}

