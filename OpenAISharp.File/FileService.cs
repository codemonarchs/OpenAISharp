using OpenAISharp.Client;
using OpenAISharp.File.Requests;
using OpenAISharp.File.Responses;
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
            => await _openAIClient.GetAsync<ListFilesResponse>("/files");

        /// <inheritdoc cref="IFileService.UploadFileAsync"/>
        public async Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request)
            => await _openAIClient.PostAsync<UploadFileRequest, UploadFileResponse>("/files", request);

        /// <inheritdoc cref="IFileService.DeleteFileAsync"/>
        public async Task<DeleteFileResponse> DeleteFileAsync(string fileId)
            => await _openAIClient.DeleteAsync<DeleteFileResponse>("/files");

        /// <inheritdoc cref="IFileService.RetrieveFileAsync"/>
        public async Task<RetrieveFileResponse> RetrieveFileAsync(string fileId)
            => await _openAIClient.GetAsync<RetrieveFileResponse>($"/files/{fileId}");

        /// <inheritdoc cref="IFileService.RetrieveFileContentAsync"/>
        public async Task<string> RetrieveFileContentAsync(string fileId)
            => await _openAIClient.GetStringAsync($"/files/{fileId}/content");
    }
}

