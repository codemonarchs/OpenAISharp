using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAISharp.Embedding.Requests
{
    public class CreateEmbeddingRequest
    {
        /// <summary>
        /// ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/embeddings/create#embeddings/create-model</remarks>
        [JsonPropertyName("model")]
        [Required]
        public string? Model { get; set; }

        /// <summary>
        /// Input text to get embeddings for, encoded as a string or array of tokens. 
        /// To get embeddings for multiple inputs in a single request, pass an array of strings or array of token arrays. 
        /// Each input must not exceed 8192 tokens in length.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/embeddings/create#embeddings/create-input</remarks>
        [JsonPropertyName("input")]
        [Required]
        public string? Input { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. Learn more.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/embeddings/create#embeddings/create-user</remarks>
        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }
    }
}

