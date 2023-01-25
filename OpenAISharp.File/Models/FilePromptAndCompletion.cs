using System;
using System.Text.Json.Serialization;

namespace OpenAISharp.File.Models
{
    public class FilePromptAndCompletion
    {
        public FilePromptAndCompletion(string prompt, string completion)
        {
            Prompt = prompt;
            Completion = completion;
        }

        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("completion")]
        public string Completion { get; set; }
    }
}
