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
            if (apiKey == null)
                throw new ArgumentNullException("OpenAI API Key is null. Did you set your environment variables using the 'set-openai-credentials.ps1' script?");
            services.AddOpenAI(apiKey, organizationId);
        }

        public void Configure(IApplicationBuilder app) { }
    }
}