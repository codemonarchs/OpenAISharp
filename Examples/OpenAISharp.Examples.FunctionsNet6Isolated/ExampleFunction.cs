using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using OpenAISharp.Client;
using OpenAISharp.Model;

namespace OpenAISharp.Examples.FunctionsNet6Isolated
{
    public class ExampleFunction
    {
        private readonly ILogger _logger;
        private readonly IModelService _modelService;

        public ExampleFunction(ILoggerFactory loggerFactory, IModelService modelService)
        {
            _logger = loggerFactory.CreateLogger<ExampleFunction>();
            _modelService = modelService;
        }

        [Function("ExampleFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            var models = await _modelService.ListModelsAsync();
            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/json");
            response.WriteString(JsonSerializer.Serialize(models));
            return response;
        }
    }
}
