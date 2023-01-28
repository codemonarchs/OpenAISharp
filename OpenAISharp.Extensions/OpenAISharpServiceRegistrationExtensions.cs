using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Client;
using OpenAISharp.Completion;
using OpenAISharp.Edit;
using OpenAISharp.Embedding;
using OpenAISharp.File;
using OpenAISharp.FineTune;
using OpenAISharp.Image;
using OpenAISharp.Model;
using OpenAISharp.Moderation;
using System;

namespace OpenAISharp.Extensions
{
    public static class OpenAISharpServiceRegistrationExtensions
    {
        /// <summary>
        /// Registers the dependencies required for interfacing with the Open AI API.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="apiKey">Your API key from Open AI.</param>
        /// <param name="organizationId">Your Organization Id from Open AI. (Optional)</param>
        /// <param name="baseUrl">The Base URL for the API. (Optional)</param>
        /// <returns></returns>
        public static IServiceCollection AddOpenAI(this IServiceCollection services, string apiKey, string organizationId = "", string baseUrl = "https://api.openai.com")
        {
            // Add OpenAISharp Dependencies and Configuration
            services.AddHttpClient<IOpenAIClient, OpenAIClient>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
                if (!string.IsNullOrWhiteSpace(organizationId))
                    client.DefaultRequestHeaders.Add("OpenAI-Organization", organizationId);
            });
            services.AddTransient<ICompletionService, CompletionService>();
            services.AddTransient<IEditService, EditService>();
            services.AddTransient<IEmbeddingService, EmbeddingService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IFineTuneService, FineTuneService>();
            services.AddTransient<IImageService, ImageService>();
            services.AddTransient<IModelService, ModelService>();
            services.AddTransient<IModerationService, ModerationService>();
            return services;
        }
    }
}
