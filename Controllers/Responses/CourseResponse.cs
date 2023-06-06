using AutoMapper;
using UniversityApi.Models;

namespace UniversityApi.Controllers.Responses;

public class CourseResponse
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public int? Credits { get; set; }
    public IList<CourseEnrollmentResponse>? Enrollments { get; set; }
}

public class CourseResponseProfile : Profile
{
    public CourseResponseProfile()
    {
        CreateMap<Course, CourseResponse>();
        CreateMap<Enrollment, CourseEnrollmentResponse>();
    }
}

public class CourseEnrollmentResponse
{
    public Guid Id { get; set; }
    public StudentResponse? Student { get; set; }
}