﻿using OpenAISharp.Client;
using OpenAISharp.Constants;
using OpenAISharp.Model.Responses;
using OpenAISharp.Utilities;
using System.Threading.Tasks;

namespace OpenAISharp.Model
{
    /// <inheritdoc cref="IModelService"/>
    public class ModelService : IModelService
    {
        private readonly IOpenAIClient _openAIClient;
        public ModelService(IOpenAIClient openAIClient) { _openAIClient = openAIClient; }

        /// <inheritdoc cref="IModelService.RetrieveModelAsync"/>
        public async Task<ListModelsResponse> ListModelsAsync()
            => await _openAIClient.GetAsync<ListModelsResponse>(string.Empty);

        /// <inheritdoc cref="IModelService.RetrieveModelAsync"/>
        public async Task<RetrieveModelResponse> RetrieveModelAsync(string model)
            => await _openAIClient.GetAsync<RetrieveModelResponse>($"/{model}");

        /// <inheritdoc cref="IModelService.RetrieveModelAsync"/>
        public async Task<RetrieveModelResponse> RetrieveModelAsync(DefaultModels model)
            => await RetrieveModelAsync($"/{ModelUtility.GetModelId(model)}");
    }
}

