using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpProgramming.WebApiParameters.Controllers
{
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        [Route("/data/no-parameters")]
        public IActionResult GetDataNoParameters()
        {
            return Ok("No parameters");
        }

        [HttpGet]
        [Route("/data/{name}")]
        public IActionResult GetDataFromRoute([FromRoute] string name)
        {
            return Ok($"Hello, {name} from route!");
        }

        [HttpGet]
        [Route("/data")]
        public IActionResult GetDataFromQuery([FromQuery] string name)
        {
            return Ok($"Hello, {name} from query!");
        }

        [HttpPost]
        [Route("/data")]
        public IActionResult GetDataFromBody([FromBody] string name)
        {
            return Ok($"Hello, {name} from body!");
        }

    }
}
