namespace UniversityApi.Models;

public class CourseAssignment
{
    // public Guid CourseAssignmentId { get; set; }
    public Guid InstructorId { get; set; }
    public Guid CourseId { get; set; }
    public Instructor Instructor { get; set; } = null!;
    public Course Course { get; set; } = null!;
    public CourseAssignment(Guid instructorId, Guid courseId)
    {
        InstructorId = instructorId;
        CourseId = courseId;
    }
}