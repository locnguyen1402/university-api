namespace UniversityApi.Models;

public enum Credit
{
    T0, T1, T2, T3, T4, T5
}

public class Course : BaseEntity
{
    public string Title { get; private set; }
    public Credit Credits { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
    public Course(string Title) : base()
    {
        this.Title = Title;
        Enrollments = new List<Enrollment>();
        CourseAssignments = new List<CourseAssignment>();
    }

    public Course(string Title, Credit Credits) : this(Title)
    {
        this.Credits = Credits;
    }

    public void UpdateTitle(string value)
    {
        Title = value;
    }

    public void UpdateCredits(Credit value)
    {
        Credits = value;
    }
}