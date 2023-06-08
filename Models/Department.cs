namespace UniversityApi.Models;

public class Department : BaseEntity
{
    public string Name { get; set; } = null!;
    public Guid? InstructorID { get; set; }
    public Instructor? Administrator { get; set; } = null;
    public ICollection<Course> Courses { get; set; } = null!;
    public Department() : base() { }
    public Department(string name, Guid? instructorId = null) : this()
    {
        Name = name;
        InstructorID = instructorId;
        Courses = new List<Course>();
    }

    public void AssignToInstructor(Guid? instructorID)
    {
        InstructorID = instructorID;
    }
}