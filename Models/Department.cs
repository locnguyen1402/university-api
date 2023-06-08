namespace UniversityApi.Models;

public class Department : BaseEntity
{
    public string Name { get; set; }
    public Guid? InstructorID { get; set; }
    public Instructor? Administrator { get; set; } = null;
    public ICollection<Course> Courses { get; set; }
    public Department(string name) : base()
    {
        Name = name;
        Courses = new List<Course>();
    }

    public void AssignToInstructor(Guid? instructorID)
    {
        InstructorID = instructorID;
    }
}