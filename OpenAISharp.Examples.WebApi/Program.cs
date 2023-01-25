using OpenAISharp.Client;
using OpenAISharp.Client.Options;
using OpenAISharp.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add OpenAISharp Dependencies and Configuration
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOpenAIClient, OpenAIClient>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.Configure<OpenAIClientOptions>(builder.Configuration.GetSection("OpenAI"));

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
