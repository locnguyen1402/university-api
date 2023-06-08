using UniversityApi.Models;

namespace UniversityApi.Controllers.Requests;

public class CreateCourseRequest
{
    public string Title { get; set; } = null!;
    public Credit Credits { get; set; }
}