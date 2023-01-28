using OpenAISharp.Client;
using OpenAISharp.Model;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OpenAISharp.Examples.ConsoleNetCore31
{
    internal class Program
    {
        static async Task Main(string[] args)
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

            Console.WriteLine(JsonSerializer.Serialize(response));
        }
    }
}
