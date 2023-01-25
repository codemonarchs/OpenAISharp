using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAISharp.Client;
using OpenAISharp.Client.Options;
using OpenAISharp.Examples.BlazorWebAssembly;
using OpenAISharp.Model;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add OpenAISharp Dependencies and Configuration
builder.Services.AddHttpClient();
builder.Services.AddScoped<IOpenAIClient, OpenAIClient>();
builder.Services.AddScoped<IModelService, ModelService>();
builder.Services.AddOptions<OpenAIClientOptions>().Configure<IConfiguration>((settings, configuration) => configuration.GetSection("OpenAI").Bind(settings));

await builder.Build().RunAsync();
