namespace UniversityApi.Controllers.Requests;

public class UpdateCourseRequest
{
    public Guid id { get; set; } = Guid.Empty;
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
}