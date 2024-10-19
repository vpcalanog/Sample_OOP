using System.Collections.Generic;
using static SampleModels.StudentModel;
using static SampleModels.InstructorModel;

namespace SampleManager.Services
{
    public interface IPersonService
    {
        // Student-related methods
        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);
        void AddStudent(Student student);
        void UpdateStudent(int id, Student student);
        void DeleteStudent(int id);

        // Instructor-related methods
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int id);
        void AddInstructor(Instructor instructor);
        void UpdateInstructor(int id, Instructor instructor);
        void DeleteInstructor(int id);
    }
}
