using OpenAISharp.Client;
using OpenAISharp.File.Requests;
using OpenAISharp.File.Responses;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenAISharp.File
{
    /// <inheritdoc cref="IFileService"/>
    public class FileService : IFileService
    {
        private readonly IOpenAIClient _openAIClient;
        public FileService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IFileService.ListFilesAsync"/>
        public async Task<ListFilesResponse> ListFilesAsync()
            => await _openAIClient.GetAsync<ListFilesResponse>("/v1/files");

        /// <inheritdoc cref="IFileService.UploadFileAsync"/>
        public async Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request)
        {
            var formData = new MultipartFormDataContent
            {
                { new StringContent(request.Purpose), "purpose" },
                { new ByteArrayContent(request.UseFilePath ? System.IO.File.ReadAllBytes(request.FileContent) : Encoding.UTF8.GetBytes(request.FileContent)), "file", request.File }
            };
            return await _openAIClient.MultiPartFormPostAsync<UploadFileResponse>("/v1/files", formData);
        }

        /// <inheritdoc cref="IFileService.DeleteFileAsync"/>
        public async Task<DeleteFileResponse> DeleteFileAsync(string fileId)
            => await _openAIClient.DeleteAsync<DeleteFileResponse>($"/v1/files/{fileId}");

        /// <inheritdoc cref="IFileService.RetrieveFileAsync"/>
        public async Task<RetrieveFileResponse> RetrieveFileAsync(string fileId)
            => await _openAIClient.GetAsync<RetrieveFileResponse>($"/v1/files/{fileId}");

        /// <inheritdoc cref="IFileService.RetrieveFileContentAsync"/>
        public async Task<string> RetrieveFileContentAsync(string fileId)
            => await _openAIClient.GetStringAsync($"/v1/files/{fileId}/content");
    }
}

