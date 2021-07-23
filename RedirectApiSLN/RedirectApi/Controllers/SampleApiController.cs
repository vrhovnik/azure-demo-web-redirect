using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedirectApi.Models;

namespace RedirectApi.Controllers
{
    [Route("demo")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        private readonly ILogger<SampleApiController> logger;

        public SampleApiController(ILogger<SampleApiController> logger)
        {
            this.logger = logger;
        }

        [Route("amialive")]
        public IActionResult HealthCheck()
        {
            logger.LogInformation("Health check was in progress");
            return Ok($"I'm alive at {DateTime.Now}");
        }

        [Route("givemejson")]
        [Produces("application/json")]
        public IActionResult ReturnJsonExampleFile()
        {
            logger.LogInformation("filling the list");
            var list = new List<Person>
            {
                new() {FullName = "John Doe"},
                new() {FullName = "John Smith", Age = 33},
                new() {FullName = "Maria Smith", Age = 30}
            };
            logger.LogInformation($"Doing serialization on the list with {list.Count} items");
            var json = JsonSerializer.Serialize(list);
            logger.LogInformation("serialization done and returning the list with demo data");
            return Ok(json);
        }
    }
}