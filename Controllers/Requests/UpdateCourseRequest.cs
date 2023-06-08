using UniversityApi.Models;

namespace UniversityApi.Controllers.Requests;

public class UpdateCourseRequest
{
    public Guid id { get; set; } = Guid.Empty;
    public string Title { get; set; } = null!;
    public Credit Credits { get; set; }
}