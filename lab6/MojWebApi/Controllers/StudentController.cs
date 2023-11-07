using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MojWebApi.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("/students")]
        public IActionResult GetAllStudents()
        {
            return Ok("Ante");
        }

        [HttpGet]
        [Route("/student/{name}")]
        public IActionResult GetStudentWithName([FromRoute]string name)
        {
            return Ok($"Hello, {name}");
        }

        [HttpGet]
        [Route("/query")]
        public IActionResult GetStudentWithName2([FromQuery] string name, [FromQuery] string surname)
        {
            return Ok($"Hello, {name} {surname}");
        }

        [HttpPost]
        [Route("/post")]
        public IActionResult PostStudent([FromBody]string name)
        {
            return Ok($"Hello, {name}");
        }

    }
}
