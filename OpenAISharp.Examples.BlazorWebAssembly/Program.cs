using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAISharp.Client;
using OpenAISharp.Client.Options;
using OpenAISharp.Completion;
using OpenAISharp.Edit;
using OpenAISharp.Embedding;
using OpenAISharp.Examples.BlazorWebAssembly;
using OpenAISharp.File;
using OpenAISharp.FineTune;
using OpenAISharp.Image;
using OpenAISharp.Model;
using OpenAISharp.Moderation;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add OpenAISharp Dependencies and Configuration
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOpenAIClient, OpenAIClient>();
builder.Services.AddOptions<OpenAIClientOptions>().Configure<IConfiguration>((settings, configuration) => configuration.GetSection("OpenAI").Bind(settings));
builder.Services.AddScoped<ICompletionService, CompletionService>();
builder.Services.AddScoped<IEditService, EditService>();
builder.Services.AddScoped<IEmbeddingService, EmbeddingService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFineTuneService, FineTuneService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModerationService, ModerationService>();

await builder.Build().RunAsync();
