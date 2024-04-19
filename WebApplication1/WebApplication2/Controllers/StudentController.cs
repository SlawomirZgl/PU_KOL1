using BLL;
using BLL.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var student = _studentService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpPost]
        public IActionResult Post(StudentCreateDTO student)
        {
            var createdStudent = _studentService.AddStudent(student);
            return CreatedAtAction(nameof(Get), new { id = createdStudent.ID }, createdStudent);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, StudentUpdateDTO student)
        {
            var updatedStudent = _studentService.UpdateStudent(id, student);
            if (updatedStudent == null)
            {
                return NotFound();
            }
            return Ok(updatedStudent);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _studentService.DeleteStudent(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }

}
