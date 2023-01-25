using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using OpenAISharp.Client.Options;
using OpenAISharp.Client;
using OpenAISharp.Model;
using Microsoft.Extensions.DependencyInjection;

var host = new HostBuilder()
    .ConfigureServices(c =>
    {
        c.AddHttpClient();
        c.AddScoped<IOpenAIClient, OpenAIClient>();
        c.AddScoped<IModelService, ModelService>();
        c.AddOptions<OpenAIClientOptions>().Configure<IConfiguration>((settings, configuration) => configuration.GetSection("OpenAI").Bind(settings));
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
