using DefaultDotnetBackend.DTOs;
using DefaultDotnetBackend.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DefaultDotnetBackend.Controller {
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : BaseController {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) {
            _logger = logger;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Home() {
            return Ok<Object>(new {
                Version = "1.0.0",
                Name = "Default Backend",
            });
        }
    }
}