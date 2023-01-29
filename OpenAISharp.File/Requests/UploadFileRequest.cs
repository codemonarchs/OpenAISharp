using System.Text.Json.Serialization;

namespace OpenAISharp.File.Requests
{
    /// <summary>
    /// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact Open AI if you need to increase the storage limit.
    /// </summary>
    /// <remarks>Used with <see cref="IFileService.UploadFileAsync"/>.</remarks>
    public class UploadFileRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileContent"></param>
        /// <param name="useFilePath"></param>
        public UploadFileRequest(string file, string? fileContent, bool useFilePath)
        {
            File = file.EndsWith(".jsonl") ? file : $"{file}.jsonl";
            FileContent = fileContent;
            UseFilePath = useFilePath;
        }

        /// <summary>
        /// Name of the JSON Lines file to be uploaded.
        /// If the purpose is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your training examples.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/files/upload#files/upload-file</remarks>
        [JsonPropertyName("file")]
        public string File { get; }

        /// <summary>
        /// The intended purpose of the uploaded documents.
        /// Use "fine-tune" for Fine-tuning.This allows us to validate the format of the uploaded file.
        /// Currently the only supported purpose is "fine-tune".
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/files/upload#files/upload-purpose</remarks>
        [JsonPropertyName("purpose")]
        public string Purpose { get; } = "fine-tune";

        /// <summary>
        /// The file content in the form of jsonlines or the path to the file containing jsonlines content.
        /// https://jsonlines.org/examples/
        /// </summary>
        [JsonIgnore]
        public string? FileContent { get; }

        /// <summary>
        /// A flag to tell the service class whether the FileContent is actual .jsonl content or if it's a file path.
        /// </summary>
        [JsonIgnore]
        public bool UseFilePath { get; }
    }
}

