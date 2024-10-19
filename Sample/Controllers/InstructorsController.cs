using Microsoft.AspNetCore.Mvc;
using SampleManager.Services;
using static SampleModels.InstructorModel;

namespace Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public InstructorsController(IPersonService personService)
        {
            _personService = personService;
        }

        // Get all instructors
        [HttpGet]
        public ActionResult<IEnumerable<Instructor>> GetInstructors()
        {
            var instructors = _personService.GetAllInstructors();
            return Ok(instructors);
        }

        // Get an instructor by ID
        [HttpGet("{id}")]
        public ActionResult<Instructor> GetInstructor(int id)
        {
            var instructor = _personService.GetInstructorById(id);
            if (instructor == null)
            {
                return NotFound();
            }
            return Ok(instructor);
        }

        // Add a new instructor
        [HttpPost]
        public ActionResult AddInstructor(Instructor instructor)
        {
            _personService.AddInstructor(instructor);
            return CreatedAtAction(nameof(GetInstructor), new { id = instructor.Id }, instructor);
        }

        // Update an existing instructor
        [HttpPut("{id}")]
        public IActionResult UpdateInstructor(int id, Instructor instructor)
        {
            var existingInstructor = _personService.GetInstructorById(id);
            if (existingInstructor == null)
            {
                return NotFound();
            }

            _personService.UpdateInstructor(id, instructor);
            return NoContent();
        }

        // Delete an instructor
        [HttpDelete("{id}")]
        public IActionResult DeleteInstructor(int id)
        {
            var instructor = _personService.GetInstructorById(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _personService.DeleteInstructor(id);
            return NoContent();
        }
    }
}
