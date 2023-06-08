namespace UniversityApi.Models;

public class Instructor : BaseEntity
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime HireDate { get; set; }
    public virtual string FullName => $"{LastName} {FirstMidName}";
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
    public Instructor(string FirstMidName, string LastName) : base()
    {
        this.LastName = LastName;
        this.FirstMidName = FirstMidName;
        CourseAssignments = new List<CourseAssignment>();
    }
}