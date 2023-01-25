using OpenAISharp.Client;
using OpenAISharp.Image.Requests;
using OpenAISharp.Image.Responses;
using System.Net.Http;
using System.Text;
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
        {
            var formData = new MultipartFormDataContent
            {
                { new ByteArrayContent(request.UseImageFilePath ? System.IO.File.ReadAllBytes(request.ImageContent) : Encoding.UTF8.GetBytes(request.ImageContent)), "image", request.Image },
                { new StringContent(request.Prompt), "prompt" },
                { new StringContent(request.N != null ? request.N.ToString() : "1"), "n" },
                { new StringContent(!string.IsNullOrWhiteSpace(request.Size) ? request.Size : "1024x1024"), "size" },
            };

            if (!string.IsNullOrWhiteSpace(request.Mask) && !string.IsNullOrWhiteSpace(request.MaskContent))
                formData.Add(new ByteArrayContent(request.UseMaskFilePath ? System.IO.File.ReadAllBytes(request.MaskContent) : Encoding.UTF8.GetBytes(request.MaskContent)), "mask", request.Mask);

            return await _openAIClient.MultiPartFormPostAsync<CreateImageEditResponse>("/images/edits", formData);
        }

        /// <inheritdoc cref="IImageService.CreateImageVarationAsync"/>
        public async Task<CreateImageVariationResponse> CreateImageVariationAsync(CreateImageVariationRequest request)
        {
            var formData = new MultipartFormDataContent
            {
                { new ByteArrayContent(request.UseImageFilePath ? System.IO.File.ReadAllBytes(request.ImageContent) : Encoding.UTF8.GetBytes(request.ImageContent)), "image", request.Image },
                { new StringContent(request.N != null ? request.N.ToString() : "1"), "n" },
                { new StringContent(!string.IsNullOrWhiteSpace(request.Size) ? request.Size : "1024x1024"), "size" },
            };
            return await _openAIClient.MultiPartFormPostAsync<CreateImageVariationResponse>("/images/variations", formData);
        }
    }
}

