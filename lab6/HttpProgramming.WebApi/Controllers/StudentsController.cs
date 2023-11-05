using HttpProgramming.Model;
using Microsoft.AspNetCore.Mvc;

namespace HttpProgramming.WebApi.Controllers;

[ApiController]
public class StudentsController : ControllerBase
{
    private readonly StudentsRepository _studentsRepository;

    public StudentsController(StudentsRepository studentsRepository)
    {
        _studentsRepository = studentsRepository;
    }

    [HttpGet]
    [Route("/students")]
    public async Task<IActionResult> GetStudents()
    {
        return Ok(_studentsRepository.GetAllStudents());
    }

    [HttpGet]
    [Route("/students/{studentId}")]
    public IActionResult GetStudent(
        [FromRoute] int studentId)
    {
        var student = _studentsRepository.GetStudent(studentId);

        return student is null ? NotFound() : Ok(student);
    }

    [HttpPost]
    [Route("/students/{studentName}")]
    public IActionResult CreateStudent(
        [FromRoute] string studentName)
    {
        _studentsRepository.CreateStudent(studentName);

        return Ok();
    }

    [HttpPut]
    [Route("/students/{studentId}/{studentName}")]
    public IActionResult UpdateStudent(
        [FromRoute] int studentId, [FromRoute] string studentName)
    {
        _studentsRepository.UpdateStudent(studentId, studentName);

        return Ok();
    }

    [HttpDelete]
    [Route("/students/{studentId}")]
    public IActionResult DeleteStudent(
        [FromRoute] int studentId)
    {
        _studentsRepository.DeleteStudent(studentId);

        return Ok();
    }
}