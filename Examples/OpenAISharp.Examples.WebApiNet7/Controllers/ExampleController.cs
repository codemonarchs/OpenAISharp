using Microsoft.AspNetCore.Mvc;
using OpenAISharp.Model;
using OpenAISharp.Model.Responses;

namespace OpenAISharp.Examples.WebApiNet7.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExampleController : ControllerBase
    {
        private readonly IModelService _modelService;

        public ExampleController(IModelService modelService)
        {
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<ListModelsResponse> GetAsync()
            => await _modelService.ListModelsAsync();
    }
}