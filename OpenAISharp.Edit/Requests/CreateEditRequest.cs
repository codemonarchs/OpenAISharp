using System.Text.Json.Serialization;

namespace OpenAISharp.Edit.Requests
{
    /// <summary>
    /// Creates a new edit for the provided input, instruction, and parameters.
    /// </summary>
    public class CreateEditRequest
    {
        /// <summary>
        /// The almighty constructor.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="instruction"></param>
        public CreateEditRequest(string model, string instruction)
        {
            Model = model;
            Instruction = instruction;
        }

        /// <summary>
        /// ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/edits/create#edits/create-model</remarks>
        [JsonPropertyName("model")]
        public string Model { get; }

        /// <summary>
        /// The input text to use as a starting point for the edit.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/edits/create#edits/create-input</remarks>
        [JsonPropertyName("input")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Input { get; set; }

        /// <summary>
        /// The instruction that tells the model how to edit the prompt.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/edits/create#edits/create-instruction</remarks>
        [JsonPropertyName("instruction")]
        public string Instruction { get; }

        /// <summary>
        /// How many edits to generate for the input and instruction.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/edits/create#edits/create-n</remarks>
        [JsonPropertyName("n")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? N { get; set; }

        /// <summary>
        /// What sampling temperature to use. Higher values means the model will take more risks. 
        /// Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.
        /// We generally recommend altering this or top_p but not both.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/edits/create#edits/create-temperature</remarks>
        [JsonPropertyName("temperature")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Temperature { get; set; }

        /// <summary>
        /// An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. 
        /// So 0.1 means only the tokens comprising the top 10% probability mass are considered.
        /// We generally recommend altering this or temperature but not both.
        /// </summary>
        /// <remarks>https://beta.openai.com/docs/api-reference/edits/create#edits/create-top_p</remarks>
        [JsonPropertyName("top_p")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TopP { get; set; }
    }
}

