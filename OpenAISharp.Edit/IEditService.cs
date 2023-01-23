using OpenAISharp.Edit.Requests;
using OpenAISharp.Edit.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Edit
{
    /// <summary>
    /// Given a prompt and an instruction, the model will return an edited version of the prompt.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/edits</remarks>
    public interface IEditService
    {
        /// <summary>
        /// Creates a new edit for the provided input, instruction, and parameters
        /// </summary>
        /// <returns>CreateEditResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/edits</remarks>
        Task<CreateEditResponse> CreateEditAsync(CreateEditRequest request);
    }
}

