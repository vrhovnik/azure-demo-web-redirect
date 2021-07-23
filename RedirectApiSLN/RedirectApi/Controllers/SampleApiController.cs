using System;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedirectApi.Helpers;

namespace RedirectApi.Controllers
{
    [Route("demo")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        private readonly ILogger<SampleApiController> logger;

        public SampleApiController(ILogger<SampleApiController> logger) => this.logger = logger;

        [Route("amialive")]
        public IActionResult HealthCheck()
        {
            logger.LogInformation("Health check was in progress");
            return Ok($"I'm alive at {DateTime.Now}");
        }

        [Route("withparam/{param}")]
        [Produces("application/json")]
        public IActionResult ReturnWithParameter(string param)
        {
            var list = StaticDataGenerator.SearchingTheList(param);
            logger.LogInformation($"Doing serialization on the filtered list with {list.Count} items");
            var json = JsonSerializer.Serialize(list);
            logger.LogInformation("serialization done and returning the list with demo data");
            return Ok(json);
        }
        
        [Route("givemejson")]
        [Produces("application/json")]
        public IActionResult ReturnJsonExampleFile()
        {
            var list = StaticDataGenerator.GetPersonList();
            logger.LogInformation($"Doing serialization on the list with {list.Count} items");
            var json = JsonSerializer.Serialize(list);
            logger.LogInformation("serialization done and returning the list with demo data");
            return Ok(json);
        }
    }
}