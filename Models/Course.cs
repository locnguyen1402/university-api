namespace UniversityApi.Models;

public class Course : BaseEntity
{
    public string Title { get; private set; }
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }

    public Course(string Title) : base()
    {
        this.Title = Title;
        Enrollments = new List<Enrollment>();
    }

    public Course(string Title, int Credits) : this(Title)
    {
        this.Credits = Credits;
    }

    public void UpdateTitle(string value)
    {
        Title = value;
    }

    public void UpdateCredits(int value)
    {
        Credits = value;
    }
}