using Microsoft.Extensions.Hosting;
using OpenAISharp.Extensions;

var host = new HostBuilder()
    .ConfigureServices(services =>
    {
        var apiKey = "<your-api-key>";
        var organizationId = "<your-organization-id>";
        services.AddOpenAI(apiKey, organizationId);
    })
    .ConfigureFunctionsWorkerDefaults()
    .Build();

host.Run();
