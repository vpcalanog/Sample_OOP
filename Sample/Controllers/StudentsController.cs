using Microsoft.AspNetCore.Mvc;
using SampleManager.Services;
using static SampleModels.StudentModel;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public StudentsController(IPersonService personService)
        {
            _personService = personService;
        }

        // Get all students
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            var students = _personService.GetAllStudents();
            return Ok(students);
        }

        // Get a student by ID
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _personService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // Add a new student
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            _personService.AddStudent(student);
            return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, student);
        }

        // Update an existing student
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _personService.GetStudentById(id);
            if (existingStudent == null)
            {
                return NotFound();
            }

            _personService.UpdateStudent(id, student);
            return NoContent();
        }

        // Delete a student
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _personService.GetStudentById(id);
            if (student == null)
            {
                return NotFound();
            }

            _personService.DeleteStudent(id);
            return NoContent();
        }
    }
}
