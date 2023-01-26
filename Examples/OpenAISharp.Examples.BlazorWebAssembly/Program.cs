using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OpenAISharp.Examples.BlazorWebAssembly;
using OpenAISharp.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add OpenAISharp Dependencies and Configuration
var apiKey = builder.Configuration["OpenAI:ApiKey"];
var organizationId = builder.Configuration["OpenAI:OrganizationId"];
builder.Services.AddOpenAI(apiKey, organizationId);

await builder.Build().RunAsync();
