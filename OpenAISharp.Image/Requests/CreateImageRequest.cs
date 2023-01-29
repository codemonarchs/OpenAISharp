using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Requests
{
    /// <summary>
    /// Creates an image given a prompt.
    /// </summary>
    /// <remarks>Used with <see cref="IImageService.CreateImageAsync"/>.</remarks>
    public class CreateImageRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="prompt"></param>
        public CreateImageRequest(string prompt)
        {
            Prompt = prompt;
        }

        /// <summary>
        /// A text description of the desired image(s). The maximum length is 1000 characters.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create#images/create-prompt</remarks>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The number of images to generate. Must be between 1 and 10.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create#images/create-n</remarks>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create#images/create-size</remarks>
        [JsonPropertyName("size")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Size { get; set; }

        /// <summary>
        /// The format in which the generated images are returned. Must be one of url or b64_json.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create#images/create-response_format</remarks>
        [JsonPropertyName("response_format")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? ResponseFormat { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create#images/create-user</remarks>
        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }
    }
}

