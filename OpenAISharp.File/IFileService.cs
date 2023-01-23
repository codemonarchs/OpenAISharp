using OpenAISharp.File.Requests;
using OpenAISharp.File.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.File
{
    /// <summary>
    /// Files are used to upload documents that can be used with features like Fine-tuning.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/files</remarks>
    public interface IFileService
    {
        /// <summary>
        /// Returns a list of files that belong to the user's organization.
        /// </summary>
        /// <returns>ListFilesResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/files</remarks>
        Task<ListFilesResponse> ListFilesAsync();

        /// <summary>
        /// Upload a file that contains document(s) to be used across various endpoints/features. 
        /// Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
        /// </summary>
        /// <returns>UploadFileResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/files</remarks>
        Task<UploadFileResponse> UploadFileAsync(UploadFileRequest request);

        /// <summary>
        /// Delete a file.
        /// </summary>
        /// <param name="fileId">The ID of the file to use for this request</param>
        /// <returns>DeleteFileResponse</returns>
        /// <remarks>DELETE https://api.openai.com/v1/files/{file_id}</remarks>
        Task<DeleteFileResponse> DeleteFileAsync(string fileId);

        /// <summary>
        /// Returns information about a specific file.
        /// </summary>
        /// <param name="fileId">The ID of the file to use for this request</param>
        /// <returns>RetrieveFileResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/files/{file_id}</remarks>
        Task<RetrieveFileResponse> RetrieveFileAsync(string fileId);

        /// <summary>
        /// Returns the contents of the specified file.
        /// </summary>
        /// <param name="fileId">The ID of the file to use for this request</param>
        /// <returns>string?</returns>
        /// <remarks>GET https://api.openai.com/v1/files/{file_id}/content</remarks>
        Task<string> RetrieveFileContentAsync(string fileId);
    }
}

