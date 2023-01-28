using System.Text.Json.Serialization;

namespace OpenAISharp.Completion.Requests
{
    /// <summary>
    /// Creates a completion for the provided prompt and parameters.
    /// </summary>
    /// <remarks>Used with <see cref="ICompletionService.CreateCompletionAsync"/>.</remarks>
    public class CreateCompletionRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="model"></param>
        public CreateCompletionRequest(string model)
        {
            Model = model;
        }

        /// <summary>
        /// ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-model</remarks>
        [JsonPropertyName("model")]
        public string Model { get; }

        /// <summary>
        /// The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.
        /// Note that &lt;|endoftext|&gt; is the document separator that the model sees during training, so if a prompt is not specified the model will generate as if from the beginning of a new document.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-prompt</remarks>
        [JsonPropertyName("prompt")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Prompt { get; set; }

        /// <summary>
        /// The suffix that comes after a completion of inserted text.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-suffix</remarks>
        [JsonPropertyName("suffix")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Suffix { get; set; }

        /// <summary>
        /// The maximum number of tokens to generate in the completion.
        /// The token count of your prompt plus max_tokens cannot exceed the model's context length. Most models have a context length of 2048 tokens (except for the newest models, which support 4096).
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-max_tokens</remarks>
        [JsonPropertyName("max_tokens")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? MaxTokens { get; set; }

        /// <summary>
        /// What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// We generally recommend altering this or top_p but not both.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-temperature</remarks>
        [JsonPropertyName("temperature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? Temperature { get; set; }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-top_p</remarks>
        [JsonPropertyName("top_p")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? TopP { get; set; }

        /// <summary>
        /// How many completions to generate for each prompt.
        /// Note: Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for max_tokens and stop.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-n</remarks>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// Whether to stream back partial progress. If set, tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-stream</remarks>
        [JsonPropertyName("stream")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Stream { get; set; }

        /// <summary>
        /// Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens. For example, if logprobs is 5, the API will return a list of the 5 most likely tokens. 
        /// The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the response.
        /// The maximum value for logprobs is 5. If you need more than this, please contact us through our Help center and describe your use case.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-logprobs</remarks>
        [JsonPropertyName("logprobs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Logprobs { get; set; }

        /// <summary>
        /// Echo back the prompt in addition to the completion.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-echo</remarks>
        [JsonPropertyName("echo")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? Echo { get; set; }

        /// <summary>
        /// Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-stop</remarks>
        [JsonPropertyName("stop")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? Stop { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-presence_penalty</remarks>
        [JsonPropertyName("presence_penalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? PresencePenalty { get; set; }

        /// <summary>
        /// Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-frequency_penalty</remarks>
        [JsonPropertyName("frequency_penalty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FrequencyPenalty { get; set; }

        /// <summary>
        /// Generates best_of completions server-side and returns the "best" (the one with the highest log probability per token). Results cannot be streamed.
        /// When used with n, best_of controls the number of candidate completions and n specifies how many to return – best_of must be greater than n.
        /// Note: Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for max_tokens and stop.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-best_of</remarks>
        [JsonPropertyName("best_of")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BestOf { get; set; }

        /// <summary>
        /// Modify the likelihood of specified tokens appearing in the completion.
        /// Accepts a json object that maps tokens (specified by their token ID in the GPT tokenizer) to an associated bias value from -100 to 100. 
        /// You can use this tokenizer tool (which works for both GPT-2 and GPT-3) to convert text to token IDs. Mathematically, the bias is added to the logits generated by the model prior to sampling. 
        /// The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.
        /// As an example, you can pass {"50256": -100} to prevent the &lt;|endoftext|&gt; token from being generated.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-logit_bias - You can utilize the OpenAISharp.Utilities library to generate the tokens needed for this endpoint.</remarks>
        [JsonPropertyName("logit_bias")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object? LogitBias { get; set; }

        /// <summary>
        /// A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/completions/create#completions/create-user</remarks>
        [JsonPropertyName("user")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? User { get; set; }
    }
}
