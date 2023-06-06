namespace UniversityApi.Controllers.Requests;

public class UpdateStudentRequest
{
    public Guid id { get; set; } = Guid.Empty;
    public string LastName { get; set; } = null!;
    public string FirstMidName { get; set; } = null!;
}