using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAISharp.Image.Requests
{
    public class CreateImageEditRequest
    {
        /// <summary>
        /// The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not provided, image must have transparency, which will be used as the mask.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/images/create-edit#images/create-edit-image</remarks>
        [JsonPropertyName("image")]
        [Required]
        public string? Image { get; set; }

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
        [Required]
        public string? Prompt { get; set; }

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
    }
}

