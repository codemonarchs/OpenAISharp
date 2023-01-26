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

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

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

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
