using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OpenAISharp.Client.Options;
using OpenAISharp.Client;
using OpenAISharp.Model;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Completion;
using OpenAISharp.Edit;
using OpenAISharp.Embedding;
using OpenAISharp.File;
using OpenAISharp.FineTune;
using OpenAISharp.Image;
using OpenAISharp.Moderation;

var host = new HostBuilder()
    .ConfigureServices(c =>
    {
        c.AddHttpClient();
        c.AddScoped<IOpenAIClient, OpenAIClient>();
        c.AddOptions<OpenAIClientOptions>().Configure<IConfiguration>((settings, configuration) => configuration.GetSection("OpenAI").Bind(settings));
        c.AddScoped<ICompletionService, CompletionService>();
        c.AddScoped<IEditService, EditService>();
        c.AddScoped<IEmbeddingService, EmbeddingService>();
        c.AddScoped<IFileService, FileService>();
        c.AddScoped<IFineTuneService, FineTuneService>();
        c.AddScoped<IImageService, ImageService>();
        c.AddScoped<IModelService, ModelService>();
        c.AddScoped<IModerationService, ModerationService>();
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
