// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using OpenAISharp.Client;
using OpenAISharp.Model;

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