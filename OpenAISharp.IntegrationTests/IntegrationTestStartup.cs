using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenAISharp.Client;
using OpenAISharp.Client.Options;
using OpenAISharp.Completion;
using OpenAISharp.Edit;
using OpenAISharp.Embedding;
using OpenAISharp.File;
using OpenAISharp.FineTune;
using OpenAISharp.Image;
using OpenAISharp.Model;
using OpenAISharp.Moderation;

namespace OpenAISharp.IntegrationTests
{
    public class IntegrationTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IOpenAIClient, OpenAIClient>();
            services.AddScoped<ICompletionService, CompletionService>();
            services.AddScoped<IEditService, EditService>();
            services.AddScoped<IEmbeddingService, EmbeddingService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IFineTuneService, FineTuneService>();
            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<IModerationService, ModerationService>();
            services.Configure<OpenAIClientOptions>(options =>
            {
                options.ApiKey = Environment.GetEnvironmentVariable("OpenAI:ApiKey");
                options.OrganizationId = Environment.GetEnvironmentVariable("OpenAI:OrganizationId");
            });
        }

        public void Configure(IApplicationBuilder app) { }
    }
}