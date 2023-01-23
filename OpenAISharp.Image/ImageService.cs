using OpenAISharp.Client;
using OpenAISharp.Image.Requests;
using OpenAISharp.Image.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Image
{
    /// <inheritdoc cref="IImageService"/>
    public class ImageService : IImageService
    {
        private readonly IOpenAIClient _openAIClient;
        public ImageService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IImageService.CreateImageAsync"/>
        public async Task<CreateImageResponse> CreateImageAsync(CreateImageRequest request)
            => await _openAIClient.PostAsync<CreateImageRequest, CreateImageResponse>("/images/generations", request);

        /// <inheritdoc cref="IImageService.CreateImageEditAsync"/>
        public async Task<CreateImageEditResponse> CreateImageEditAsync(CreateImageEditRequest request)
            => await _openAIClient.PostAsync<CreateImageEditRequest, CreateImageEditResponse>("/images/edits", request);

        /// <inheritdoc cref="IImageService.CreateImageVarationAsync"/>
        public async Task<CreateImageVariationResponse> CreateImageEditAsync(CreateImageVariationRequest request)
            => await _openAIClient.PostAsync<CreateImageVariationRequest, CreateImageVariationResponse>("/images/variations", request);
    }
}

