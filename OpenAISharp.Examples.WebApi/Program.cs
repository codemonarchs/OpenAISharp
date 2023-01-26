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

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add OpenAISharp Dependencies and Configuration
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOpenAIClient, OpenAIClient>();
builder.Services.Configure<OpenAIClientOptions>(builder.Configuration.GetSection("OpenAI"));
builder.Services.AddScoped<ICompletionService, CompletionService>();
builder.Services.AddScoped<IEditService, EditService>();
builder.Services.AddScoped<IEmbeddingService, EmbeddingService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IFineTuneService, FineTuneService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddScoped<IModerationService, ModerationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
