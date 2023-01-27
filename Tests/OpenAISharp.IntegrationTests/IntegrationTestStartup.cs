using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Extensions;

namespace OpenAISharp.IntegrationTests
{
    public class IntegrationTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var apiKey = Environment.GetEnvironmentVariable("OpenAI:ApiKey");
            var organizationId = Environment.GetEnvironmentVariable("OpenAI:OrganizationId");
            services.AddOpenAI(apiKey, organizationId);
        }

        public void Configure(IApplicationBuilder app) { }
    }
}