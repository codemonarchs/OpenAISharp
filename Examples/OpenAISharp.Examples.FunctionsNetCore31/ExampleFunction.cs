using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using OpenAISharp.Client;
using OpenAISharp.Model;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAISharp.Examples.FunctionsNetCore31
{
    public static class ExampleFunction
    {
        [FunctionName("ExampleFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var apiKey = "<your-api-key>";
            var organizationId = "<your-organization-id>";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.openai.com");
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            if (!string.IsNullOrWhiteSpace(organizationId))
                httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", organizationId);

            var openAIClient = new OpenAIClient(httpClient);
            var modelService = new ModelService(openAIClient);

            var response = await modelService.ListModelsAsync();

            return new OkObjectResult(JsonSerializer.Serialize(response));
        }
    }
}
