namespace UniversityApi.Controllers.Requests;

public class CreateCourseRequest
{
    public string Title { get; set; } = null!;
    public int Credits { get; set; }
}