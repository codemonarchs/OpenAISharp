﻿using OpenAISharp.Client;
using OpenAISharp.Model.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Model
{
    /// <inheritdoc cref="IModelService"/>
    public class ModelService : IModelService
    {
        private readonly IOpenAIClient _openAIClient;

        /// <inheritdoc cref="IModelService"/>
        public ModelService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IModelService.RetrieveModelAsync"/>
        public async Task<ListModelsResponse> ListModelsAsync()
            => await _openAIClient.GetAsync<ListModelsResponse>("/v1/models");

        /// <inheritdoc cref="IModelService.RetrieveModelAsync"/>
        public async Task<RetrieveModelResponse> RetrieveModelAsync(string model)
            => await _openAIClient.GetAsync<RetrieveModelResponse>($"/v1/models/{model}");
    }
}

