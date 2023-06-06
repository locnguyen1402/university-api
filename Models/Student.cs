namespace UniversityApi.Models;

public class Student : BaseEntity
{
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollmentDate { get; set; }
    private readonly IList<Enrollment> _enrollments;
    public ICollection<Enrollment> Enrollments => _enrollments;
    public virtual string FullName => $"{LastName} {FirstMidName}";
    public Student(string FirstMidName, string LastName) : base()
    {
        this.LastName = LastName;
        this.FirstMidName = FirstMidName;
        this.EnrollmentDate = DateTime.UtcNow;
        _enrollments = new List<Enrollment>();
    }

    public Student(string FirstMidName, string LastName, DateTime EnrollmentDate) : this(FirstMidName, LastName)
    {
        this.EnrollmentDate = EnrollmentDate;
    }

    public string GetFullName()
    {
        return $"{LastName} {FirstMidName}";
    }
    public void UpdateName(string firstMidName, string lastName)
    {
        FirstMidName = firstMidName;
        LastName = lastName;
    }

    public void UpdateEnrollmentDate(DateTime date)
    {
        EnrollmentDate = date;
    }

}