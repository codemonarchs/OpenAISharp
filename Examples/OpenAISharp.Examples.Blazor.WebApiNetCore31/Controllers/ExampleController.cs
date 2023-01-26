using Microsoft.AspNetCore.Mvc;
using OpenAISharp.Model;
using OpenAISharp.Model.Responses;
using System.Threading.Tasks;

namespace OpenAISharp.Examples.WebApiNetCore31.Controllers
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