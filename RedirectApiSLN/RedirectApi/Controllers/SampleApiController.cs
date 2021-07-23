using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RedirectApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class SampleApiController : ControllerBase
    {
        private readonly ILogger<SampleApiController> logger;

        public SampleApiController(ILogger<SampleApiController> logger)
        {
            this.logger = logger;
        }

        [Route("amialive")]
        public IActionResult HealthCheck() => Ok($"I'm alive at {DateTime.Now}");
    }
}