using static SampleModels.PersonModel;

namespace SampleModels
{
    public class StudentModel
    {
        public class Student : Person
        {
            public string Course { get; set; }
        }
    }
}
