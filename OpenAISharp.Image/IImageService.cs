using OpenAISharp.Image.Requests;
using OpenAISharp.Image.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Image
{
    /// <summary>
    /// Given a prompt and/or an input image, the model will generate a new image.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/images</remarks>
    public interface IImageService
    {
        /// <summary>
        /// Creates an image given a prompt.
        /// </summary>
        /// <returns>CreateImageResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/images/generations</remarks>
        Task<CreateImageResponse> CreateImageAsync(CreateImageRequest request);

        /// <summary>
        /// Creates an edited or extended image given an original image and a prompt.
        /// </summary>
        /// <returns>CreateImageEditResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/images/edits</remarks>
        Task<CreateImageEditResponse> CreateImageEditAsync(CreateImageEditRequest request);

        /// <summary>
        /// Creates a variation of a given image.
        /// </summary>
        /// <returns>CreateImageVariationResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/images/variations</remarks>
        Task<CreateImageVariationResponse> CreateImageEditAsync(CreateImageVariationRequest request);
    }
}

