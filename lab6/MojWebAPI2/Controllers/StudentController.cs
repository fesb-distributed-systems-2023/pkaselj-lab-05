using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MojWebAPI2.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("/students")]
        public IActionResult GetStudents()
        {
            return Ok("Ante");
        }

        [HttpGet]
        [Route("/getstudent/{name}/{surname}")]
        public IActionResult GetStudentByName([FromRoute]string name, [FromRoute]string surname)
        {
            return Ok($"Hello, {name} {surname}");
        }

        [HttpGet]
        [Route("/search")]
        public IActionResult GetStudentByName2([FromQuery] string name, [FromQuery]string surname)
        {
            return Ok($"Hello, {name} {surname}");
        }

        [HttpPost]
        [Route("/student/frombody")]
        public IActionResult GetStudentByName3([FromBody]string name)
        {
            return Ok($"Hello, {name}");
        }
    }
}
