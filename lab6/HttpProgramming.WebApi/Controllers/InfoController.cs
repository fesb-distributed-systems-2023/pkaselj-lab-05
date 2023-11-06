using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpProgramming.WebApi.Controllers
{
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        [Route("/info")]
        public IActionResult GetInfo()
        {
            return Ok("Hello from server");
        }

        [HttpGet]
        [Route("/info/{message}")]
        public IActionResult GetInfo([FromRoute] string message)
        {
            return Ok($"You sent: '{message}'. Hello from server.");
        }

        [HttpPost]
        [Route("/info")]
        public IActionResult PostInfo([FromBody] string message)
        {
            return Ok($"You sent: '{message}'. Hello from server.");
        }

    }
}
