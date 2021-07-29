using System;
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
            return Ok(list);
        }
        
        [Route("catch/{**catchAll}")]
        [Produces("application/json")]
        public IActionResult CatchAll(string catchAll)
        {
            var list = StaticDataGenerator.GetPersonList();
            if (string.IsNullOrEmpty(catchAll)) return Ok(list);

            //lets assume, we have /demo/catch/api/call, api/call will be forwarded to the call
            var param = catchAll.Split("/");

            if (param.Length < 1) return NotFound("Data length was not appropriate");

            var parameter = $"{param[0]} {param[1]}"; //remove the need for / parameter
            list = StaticDataGenerator.SearchingTheList(parameter);
            logger.LogInformation($"Doing check with {parameter} on the list with {list.Count} items");
            return Ok(list);
        }

        [Route("withencodedparam/{param}")]
        [Produces("application/json")]
        public IActionResult ReturnWithEncodedParameter(string param)
        {
            //replace with %252F
            if (param.Contains("%2F")) param = param.Replace("%2F", "%252F");
            
            var list = StaticDataGenerator.SearchingTheListWithEncoded(param);
            logger.LogInformation($"Doing serialization on the filtered list with {list.Count} items");
            return Ok(list);
        }

        [Route("givemejson")]
        public IActionResult ReturnJsonExampleFile()
        {
            var list = StaticDataGenerator.GetPersonListAsMemoryStream();
            logger.LogInformation($"Doing serialization on the memory stream with {list.Length} in byte size");
            return File(list, "application/json", "persons.json");
        }
    }
}