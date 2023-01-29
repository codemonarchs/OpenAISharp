using System.Text.Json.Serialization;

namespace OpenAISharp.File.Models
{
    /// <summary>
    /// A class used to help serialized a list of prompts and completions into JSONL format.
    /// </summary>
    public class FilePromptAndCompletion
    {
        /// <summary>
        /// A class used to help serialized a list of prompts and completions into JSONL format.
        /// </summary>
        /// <param name="prompt">The prompt for the AI.</param>
        /// <param name="completion">The completion for the AI.</param>
        /// <inheritdoc cref="FilePromptAndCompletion"/>
        public FilePromptAndCompletion(string prompt, string completion)
        {
            Prompt = prompt;
            Completion = completion;
        }

        /// <summary>
        /// The prompt for the AI.
        /// </summary>
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        /// <summary>
        /// The completion for the AI.
        /// </summary>
        [JsonPropertyName("completion")]
        public string Completion { get; set; }
    }
}
