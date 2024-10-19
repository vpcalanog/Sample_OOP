using SampleManager.Services;
using SampleManager.Context;
using static SampleModels.InstructorModel;
using static SampleModels.StudentModel;

namespace SampleManager.Managers
{
    public class PersonManager : IPersonService
    {
        private readonly ApplicationDbContext _context;

        public PersonManager(ApplicationDbContext context)
        {
            _context = context;
        }
        //// Temporary data for testing
        //private readonly List<Student> _students = new List<Student>
        //{
        //    new Student { Id = 1, FirstName = "John", LastName = "Doe", Course = "Computer Science" },
        //    new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Course = "Information Technology" }
        //};

        //private readonly List<Instructor> _instructors = new List<Instructor>
        //{
        //    new Instructor { Id = 1, FirstName = "Michael", LastName = "Brown", Department = "Computer Science", YearsOfExperience = 10 },
        //    new Instructor { Id = 2, FirstName = "Susan", LastName = "Green", Department = "Information Technology", YearsOfExperience = 8 }
        //};

        // Student methods
        public IEnumerable<Student> GetAllStudents() => _context.Students.ToList();

        public Student GetStudentById(int id) => _context.Students.Find(id);

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(int id, Student student)
        {
            var existingStudent = _context.Students.Find(id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Course = student.Course;
                _context.SaveChanges();
            }
        }

        public void DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        // Instructor methods
        public IEnumerable<Instructor> GetAllInstructors() => _context.Instructors.ToList();

        public Instructor GetInstructorById(int id) => _context.Instructors.Find(id);

        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public void UpdateInstructor(int id, Instructor instructor)
        {
            var existingInstructor = _context.Instructors.Find(id);
            if (existingInstructor != null)
            {
                existingInstructor.FirstName = instructor.FirstName;
                existingInstructor.LastName = instructor.LastName;
                existingInstructor.Department = instructor.Department;
                existingInstructor.YearsOfExperience = instructor.YearsOfExperience;
                _context.SaveChanges();
            }
        }

        public void DeleteInstructor(int id)
        {
            var instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }
    }
}
