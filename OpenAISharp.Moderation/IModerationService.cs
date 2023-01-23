using OpenAISharp.Moderation.Requests;
using OpenAISharp.Moderation.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Moderation
{
    /// <summary>
    /// Given a input text, outputs if the model classifies it as violating OpenAI's content policy.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/moderations</remarks>
    public interface IModerationService
    {
        /// <summary>
        /// Classifies if text violates OpenAI's Content Policy.
        /// </summary>
        /// <returns>CreateModerationResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/moderations</remarks>
        Task<CreateModerationResponse> CreateModerationAsync(CreateModerationRequest request);
    }
}

