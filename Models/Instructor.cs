namespace UniversityApi.Models;

public class Instructor : BaseEntity
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime HireDate { get; set; }
    public virtual string FullName => $"{LastName} {FirstMidName}";
    public ICollection<CourseAssignment> CourseAssignments { get; set; }
    public Instructor() : base() { }
    public Instructor(string FirstMidName, string LastName, DateTime? HireDate = null) : this()
    {
        this.LastName = LastName;
        this.FirstMidName = FirstMidName;
        this.HireDate = (DateTime)(HireDate == null ? DateTime.UtcNow : HireDate);
        CourseAssignments = new List<CourseAssignment>();
    }
}