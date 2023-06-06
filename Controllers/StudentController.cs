using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UniversityApi.Controllers.Queries;
using UniversityApi.Controllers.Requests;
using UniversityApi.Controllers.Responses;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;
using UniversityApi.Utils;

namespace UniversityApi.Controllers;
public class StudentController : BaseController
{
    private IStudentRepository _studentRepo;
    private ICourseRepository _courseRepo;
    private IEnrollmentRepository _enrollmentRepo;

    public StudentController(
        ILogger<CourseController> logger,
        IMapper mapper,
        IStudentRepository studentRepository,
        ICourseRepository courseRepository,
        IEnrollmentRepository enrollmentRepository
    ) : base(logger, mapper)
    {
        _studentRepo = studentRepository;
        _courseRepo = courseRepository;
        _enrollmentRepo = enrollmentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetStudents([FromQuery] GetStudentsQuery queryInfo)
    {
        var query = _studentRepo.Query.Include(s => s.Enrollments).AsQueryable();

        if (!String.IsNullOrEmpty(queryInfo.keyword))
        {
            query = query.Where(s => s.FirstMidName.ToLower().Contains(queryInfo.keyword.ToLower()) || s.LastName.ToLower().Contains(queryInfo.keyword.ToLower()));
        }

        var list = await PaginationInfo.ToPaginatedListAsync(queryInfo.Page, queryInfo.PageSize, query);

        await PaginationInfo.AttachPaginationInfoToHeader(queryInfo.Page, queryInfo.PageSize, query);

        return Ok(_mapper.Map<List<StudentResponse>>(list));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetStudent(Guid id)
    {
        var student = await _studentRepo.GetStudentById(id);

        if (student == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<StudentResponse>(student));
    }

    [HttpPost]
    public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequest request)
    {
        if (request.FirstMidName.IsNullOrEmpty() || request.LastName.IsNullOrEmpty())
        {
            return BadRequest();
        }

        var student = new Student(request.FirstMidName, request.LastName);

        if (request.EnrollmentDate != null)
        {
            student.UpdateEnrollmentDate(request.EnrollmentDate);
        }

        var result = await _studentRepo.AddAsync(student);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateStudent(Guid id, [FromBody] UpdateStudentRequest request)
    {
        if (request.FirstMidName.IsNullOrEmpty() || request.LastName.IsNullOrEmpty() || id != request.id)
        {
            return BadRequest();
        }

        var student = await _studentRepo.GetStudentById(id);

        if (student == null)
        {
            return NotFound();
        }

        student.UpdateName(request.FirstMidName, request.LastName);
        var result = await _studentRepo.UpdateAsync(student);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var student = await _studentRepo.GetStudentById(id);

        if (student == null)
        {
            return NotFound();
        }

        await _studentRepo.RemoveAsync(student);

        return Ok();
    }
    [HttpPut("{id:guid}/join-in/{courseId:guid}")]
    public async Task<IActionResult> JoinIn(Guid id, Guid courseId)
    {
        var isJoiningIn = await _enrollmentRepo.IsExistedAsync(id, courseId);

        if (isJoiningIn)
        {
            return BadRequest(new { message = "Already join in this course" });
        }

        var enrollment = new Enrollment(courseId, id);

        var result = await _enrollmentRepo.AddAsync(enrollment);

        return Ok(result);
    }

    [HttpPut("{id:guid}/join-in/{courseId:guid}/leave")]
    public async Task<IActionResult> LeaveCourse(Guid id, Guid courseId)
    {
        var enrollment = await _enrollmentRepo.GetEnrollment(id, courseId);

        if (enrollment == null)
        {
            return BadRequest(new { message = "Student doest not join in this course" });
        }

        await _enrollmentRepo.RemoveAsync(enrollment);

        return Ok();
    }

    [HttpGet("{id:guid}/courses")]
    public async Task<IActionResult> GetEnrolledCourses(Guid id, [FromQuery] GetEnrolledCoursesQuery queryInfo)
    {
        var query = _enrollmentRepo.Query
                        .Include(s => s.Course)
                        .Include(s => s.Student)
                        .Where(s => s.StudentId == id);

        if (!queryInfo.CourseId.ToString().IsNullOrEmpty())
        {
            query = query.Where(s => s.CourseId == queryInfo.CourseId);
        }

        var result = await query.ToListAsync();

        return Ok(_mapper.Map<List<EnrollmentResponse>>(result));
    }
}