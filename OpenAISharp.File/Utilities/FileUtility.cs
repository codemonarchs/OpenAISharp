using OpenAISharp.File.Models;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace OpenAISharp.File.Utilities
{
    public class FileUtility
    {
        /// <summary>
        /// Converts a list of prompt and completions into .jsonl format for uploading files.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string ToJsonL(IEnumerable<FilePromptAndCompletion> data)
        {
            var sb = new StringBuilder();
            foreach (var item in data)
                sb.AppendLine(JsonSerializer.Serialize(item));
            return sb.ToString();
        }
    }
}
