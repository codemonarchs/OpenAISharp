using System.Text.Json.Serialization;

namespace OpenAISharp.File.Requests
{
    public class UploadFileRequest
    {
        /// <summary>
        /// Name of the JSON Lines file to be uploaded.
        /// If the purpose is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your training examples.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/files/upload#files/upload-file</remarks>
        [JsonPropertyName("string?")]
        public string File { get; set; }

        /// <summary>
        /// The intended purpose of the uploaded documents.
        /// Use "fine-tune" for Fine-tuning.This allows us to validate the format of the uploaded file.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/files/upload#files/upload-purpose</remarks>
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }
    }
}

