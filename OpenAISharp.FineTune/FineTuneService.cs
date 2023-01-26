using OpenAISharp.Client;
using OpenAISharp.FineTune.Requests;
using OpenAISharp.FineTune.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenAISharp.FineTune
{
    /// <inheritdoc cref="IFineTuneService"/>
    public class FineTuneService : IFineTuneService
    {
        private readonly IOpenAIClient _openAIClient;
        public FineTuneService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IFineTuneService.CreateFineTuneAsync"/>
        public async Task<CreateFineTuneResponse> CreateFineTuneAsync(CreateFineTuneRequest request)
            => await _openAIClient.PostAsync<CreateFineTuneRequest, CreateFineTuneResponse>("/v1/fine-tunes", request);

        /// <inheritdoc cref="IFineTuneService.ListFineTunesAsync"/>
        public async Task<ListFineTunesResponse> ListFineTunesAsync()
           => await _openAIClient.GetAsync<ListFineTunesResponse>("/v1/fine-tunes");

        /// <inheritdoc cref="IFineTuneService.RetrieveFineTuneAsync"/>
        public async Task<RetrieveFineTuneResponse> RetrieveFineTuneAsync(string fineTuneId)
           => await _openAIClient.GetAsync<RetrieveFineTuneResponse>($"/v1/fine-tunes/{fineTuneId}");

        /// <inheritdoc cref="IFineTuneService.CancelFineTuneAsync"/>
        public async Task<CancelFineTuneResponse> CancelFineTuneAsync(string fineTuneId)
            => await _openAIClient.PostEmptyBodyAsync<CancelFineTuneResponse>($"/v1/fine-tunes/{fineTuneId}/cancel");

        /// <inheritdoc cref="IFineTuneService.ListFineTuneEventsAsync"/>
        public async Task<ListFineTuneEventsResponse> ListFineTuneEventsAsync(string fineTuneId, bool? stream = null)
            => stream == null || (stream.HasValue && !stream.Value)
                ? await _openAIClient.GetWithQueryParametersAsync<ListFineTuneEventsResponse>($"/v1/fine-tunes/{fineTuneId}/events", stream != null ? new Dictionary<string, object> { { nameof(stream), stream.ToString().ToLower() } } : null)
                : throw new NotImplementedException("Streamed events not currently supported in OpenAISharp. Set 'stream' to null or 'false' for the time being.");

        /// <inheritdoc cref="IFineTuneService.DeleteFineTuneModelAsync"/>
        public async Task<DeleteFineTuneModelResponse> DeleteFineTuneModelAsync(string model)
           => await _openAIClient.DeleteAsync<DeleteFineTuneModelResponse>($"/v1/models/{model}");
    }
}

