using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using OpenAISharp.Extensions;
using System.Diagnostics.CodeAnalysis;

namespace OpenAISharp.IntegrationTests
{
    /// <summary>
    /// Implementation of the Startup class for a Web API but specifically used for Integration Testing.
    /// </summary>
    public class IntegrationTestStartup
    {
        /// <summary>
        /// The configure services method.
        /// </summary>
        /// <param name="services"></param>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Need this to match the signature of Startup.Configure to use this for creating a TestServer.")]
        public void ConfigureServices(IServiceCollection services)
        {
            var apiKey = Environment.GetEnvironmentVariable("OpenAI:ApiKey");
            var organizationId = Environment.GetEnvironmentVariable("OpenAI:OrganizationId") ?? string.Empty;
            if (apiKey == null)
                throw new ArgumentNullException(apiKey, "OpenAI API Key is null. Did you set your environment variables using the 'set-openai-credentials.ps1' script?");
            services.AddOpenAI(apiKey, organizationId);
        }

        /// <summary>
        /// The configure method.
        /// </summary>
        /// <param name="app"></param>
        [SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Need this to match the signature of Startup.Configure to use this for creating a TestServer.")]
        [SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Need this to match the signature of Startup.Configure to use this for creating a TestServer.")]
        public void Configure(IApplicationBuilder app) { }

        /// <summary>
        /// Get one of the libraries registered services.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public static TService GetService<TService>()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<IntegrationTestStartup>());
            var service = server.Host.Services.GetService<TService>();
            if (service == null)
                throw new NullReferenceException($"{nameof(TService)} is null in an integrationtest. Did you register it in IntegrationTestStartUp?");
            return service;
        }
    }
}