using HttpProgramming.WebApiParameters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpProgramming.WebApiParameters.Controllers
{
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        [Route("/student")]
        public IActionResult AddStudentFromQuery([FromQuery] Student student)
        {
            return Ok($"You added a new student ({student.Name}, {student.Surname}, {student.GPA}) from QUERY!");
        }

        [HttpPost]
        [Route("/student")]
        public IActionResult AddStudentFromBody([FromBody] Student student)
        {
            return Ok($"You added a new student ({student.Name}, {student.Surname}, {student.GPA}) from BODY!");
        }

        [HttpGet]
        [Route("/student/multiple")]
        public IActionResult AddMultipleStudentsFromQuery([FromQuery] IEnumerable<Student> student_list)
        {
            string response_message = "From QUERY:\n";

            foreach (var student in student_list)
            {
                response_message += $"({student.Name}, {student.Surname}, {student.GPA})\n";
            }

            return Ok(response_message);
        }

        [HttpPost]
        [Route("/student/multiple")]
        public IActionResult AddMultipleStudentsFromBody([FromBody] IEnumerable<Student> student_list)
        {
            string response_message = "From BODY:\n";

            foreach (var student in student_list)
            {
                response_message += $"({student.Name}, {student.Surname}, {student.GPA})\n";
            }

            return Ok(response_message);
        }
    }
}
