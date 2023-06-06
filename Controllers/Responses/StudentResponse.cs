using AutoMapper;
using UniversityApi.Models;

namespace UniversityApi.Controllers.Responses;

public class StudentResponse
{
    public Guid? Id { get; set; }
    public string? LastName { get; set; }
    public string? FirstMidName { get; set; }
    public string? FullName { get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public IList<StudentEnrollmentResponse>? Enrollments { get; set; }
    public int? TotalEnrollments { get; set; }
}

public class StudentResponseProfile : Profile
{
    public StudentResponseProfile()
    {
        CreateMap<Student, StudentResponse>()
            .ForMember(s => s.TotalEnrollments, s => s.MapFrom(c => c.Enrollments.Count));
        CreateMap<Enrollment, StudentEnrollmentResponse>();
    }
}

public class StudentEnrollmentResponse
{
    public Guid Id { get; set; }
    public CourseResponse? Course { get; set; }
}