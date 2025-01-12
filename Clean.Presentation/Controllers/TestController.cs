using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Application.LoggerServices;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Presentation.Controllers
{
    [ApiController]
    [Route("/api/test")]
    public class TestController : ControllerBase
    {
        private readonly ILoggerManager _logger;

        public TestController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult Test()
        {
            _logger.LogError("Logged");
            return Ok("Reached");
        }

    }
}