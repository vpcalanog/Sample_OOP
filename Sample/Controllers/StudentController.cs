using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleManager.Services;
using static SampleModels.StudentModel;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class StudentsController : ControllerBase
        {
            private readonly IStudentService _studentService;

            public StudentsController(IStudentService studentService)
            {
                _studentService = studentService;
            }

            [HttpGet]
            public ActionResult<IEnumerable<Student>> GetStudents()
            {
                return Ok(_studentService.GetAllStudents());
            }

            [HttpGet("{id}")]
            public ActionResult<Student> GetStudent(int id)
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }

            [HttpPost]
            public ActionResult AddStudent(Student student)
            {
                _studentService.AddStudent(student);
                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
            }

            [HttpPut("{id}")]
            public IActionResult UpdateStudent(int id, Student student)
            {
                var existingStudent = _studentService.GetStudentById(id);
                if (existingStudent == null)
                {
                    return NotFound();
                }

                _studentService.UpdateStudent(id, student);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteStudent(int id)
            {
                var student = _studentService.GetStudentById(id);
                if (student == null)
                {
                    return NotFound();
                }

                _studentService.DeleteStudent(id);
                return NoContent();
            }
        }
    }