using SampleManager.Services;
using static SampleModels.StudentModel;

namespace SampleManager.Managers
{
    public class StudentManager : IStudentService
    {
        //Temporary data for testing before database connections
        private readonly List<Student> _students = new List<Student>
        {
            new Student { Id = 1, FirstName = "John", LastName = "Doe", Course = "Computer Science" },
            new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Course = "Information Technology" }
        };

        //Function that displays all students within the list
        public IEnumerable<Student> GetAllStudents()
        {
            return _students;
        }
        //Function to display the details of the student if there is a matching Id
        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }
        //Function that displays adds a students to the list
        public void AddStudent(Student student)
        {
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }
        //Function that update a student's information if it exists
        public void UpdateStudent(int id, Student student)
        {
            var existingStudent = _students.FirstOrDefault(s => s.Id == id);
            if (existingStudent != null)
            {
                existingStudent.FirstName = student.FirstName;
                existingStudent.LastName = student.LastName;
                existingStudent.Course = student.Course;
            }
        }
        //Function that deletes a student from the list
        public void DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
        }
    }
}
