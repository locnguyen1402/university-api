namespace UniversityApi.Models;

public enum Grade
{
    A, B, C, D, F
}

public class Enrollment : BaseEntity
{
    public Guid CourseId { get; set; }
    public Guid StudentId { get; set; }
    public Grade? Grade { get; set; }

    public virtual Course Course { get; private set; } = null!;
    public virtual Student Student { get; set; } = null!;

    // for EFC
    public Enrollment() : base() { }
    public Enrollment(Guid courseId, Guid studentId) : this()
    {
        CourseId = courseId;
        StudentId = studentId;
    }
}