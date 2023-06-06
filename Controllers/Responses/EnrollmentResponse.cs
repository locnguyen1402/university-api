using AutoMapper;
using UniversityApi.Models;

namespace UniversityApi.Controllers.Responses;

public class EnrollmentResponse
{
    public Guid? Id { get; set; }
    public Grade? Grade { get; set; }
    public EnrollmentStudentResponse? Student { get; set; }
    public EnrollmentCourseResponse? Course { get; set; }
}

public class EnrollmentResponseProfile : Profile
{
    public EnrollmentResponseProfile()
    {
        CreateMap<Enrollment, EnrollmentResponse>();
        CreateMap<Student, EnrollmentStudentResponse>();
        CreateMap<Course, EnrollmentCourseResponse>();
    }
}

public class EnrollmentStudentResponse
{
    public Guid? Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstMidName { get; set; }
    public string? FullName { get; set; }
    public DateTime EnrollmentDate { get; set; }
}

public class EnrollmentCourseResponse
{
    public Guid? Id { get; set; }
    public string? Title { get; set; }
    public int Credits { get; set; }
}