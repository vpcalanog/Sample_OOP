using static SampleModels.PersonModel;

namespace SampleModels
{
    public class InstructorModel
    {
        public class Instructor : Person
        {
            public string Department { get; set; }
            public int YearsOfExperience { get; set; }
        }
    }
}
