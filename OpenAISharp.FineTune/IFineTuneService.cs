using OpenAISharp.FineTune.Requests;
using OpenAISharp.FineTune.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.FineTune
{
    /// <summary>
    /// Manage fine-tuning jobs to tailor a model to your specific training data.
    /// </summary>
    /// <remarks>https://beta.openai.com/docs/api-reference/fine-tunes</remarks>
    public interface IFineTuneService
    {
        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset. Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
        /// </summary>
        /// <returns>CreateFineTuneResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/fine-tunes</remarks>
        Task<CreateFineTuneResponse> CreateFineTuneAsync(CreateFineTuneRequest request);

        /// <summary>
        /// List your organization's fine-tuning jobs.
        /// </summary>
        /// <returns>ListFineTunesResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/fine-tunes</remarks>
        Task<ListFineTunesResponse> ListFineTunesAsync();

        /// <summary>
        /// Gets info about the fine-tune job.
        /// </summary>
        /// <returns>RetrieveFineTuneResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/fine-tunes/{fine_tune_id}</remarks>
        Task<RetrieveFineTuneResponse> RetrieveFineTuneAsync(string fineTuneId);

        /// <summary>
        /// Immediately cancel a fine-tune job.
        /// </summary>
        /// <returns>CancelFineTuneResponse</returns>
        /// <remarks>POST https://api.openai.com/v1/fine-tunes/{fine_tune_id}/cancel</remarks>
        Task<CancelFineTuneResponse> CancelFineTuneAsync(string fineTuneId);

        /// <summary>
        /// Get fine-grained status updates for a fine-tune job.
        /// </summary>
        /// <returns>CancelFineTuneResponse</returns>
        /// <remarks>GET https://api.openai.com/v1/fine-tunes/{fine_tune_id}/events</remarks>
        Task<ListFineTuneEventsResponse> ListFineTuneEventsAsync(string fineTuneId, bool? stream = null);


        /// <summary>
        /// Delete a fine-tuned model. You must have the Owner role in your organization.
        /// </summary>
        /// <returns>DeleteFineTuneModelResponse</returns>
        /// <remarks>DELETE https://api.openai.com/v1/models/{model}</remarks>
        Task<DeleteFineTuneModelResponse> DeleteFineTuneModelAsync(string model);
    }
}

