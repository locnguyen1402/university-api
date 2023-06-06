namespace UniversityApi.Controllers.Requests;

public class CreateStudentRequest
{
    public string LastName { get; set; } = null!;
    public string FirstMidName { get; set; } = null!;
    public DateTime EnrollmentDate { get; set; }
}