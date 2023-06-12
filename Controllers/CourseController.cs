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
public class CourseController : BaseController
{
    private ICourseRepository _courseRepo;
    private IEnrollmentRepository _enrollmentRepo;
    private IStudentRepository _studentRepo;

    public CourseController(
        ILogger<CourseController> logger,
        IMapper mapper,
        ICourseRepository courseRepository,
        IEnrollmentRepository enrollmentRepository,
        IStudentRepository studentRepository
    ) : base(logger, mapper)
    {
        _courseRepo = courseRepository;
        _enrollmentRepo = enrollmentRepository;
        _studentRepo = studentRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        return Ok();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCourse(Guid id)
    {
        var item = await _courseRepo.GetCourseByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<CourseResponse>(item));
    }

    [HttpGet("{id:guid}/students")]
    public async Task<IActionResult> GetStudentsInCourse(Guid id, [FromQuery] BaseListQuery queryInfo)
    {
        var item = await _courseRepo.GetCourseByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var query = _studentRepo.Query
                        .Where(s => s.Enrollments.Any(t => t.CourseId == id));

        var list = await PaginationInfo.ToPaginatedListAsync(queryInfo.Page, queryInfo.PageSize, query);

        await PaginationInfo.AttachPaginationInfoToHeader(queryInfo.Page, queryInfo.PageSize, query);

        return Ok(_mapper.Map<List<StudentResponse>>(list));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest request)
    {
        if (request.Credits.ToString().IsNullOrEmpty() || request.Title.IsNullOrEmpty())
        {
            return BadRequest();
        }

        var course = new Course(request.Title, request.Credits);

        var result = await _courseRepo.AddAsync(course);

        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCourse(Guid id, [FromBody] UpdateCourseRequest request)
    {
        if (request.Credits.ToString().IsNullOrEmpty() || request.Title.IsNullOrEmpty() || id != request.id)
        {
            return BadRequest();
        }

        var item = await _courseRepo.GetCourseByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        var isExisted = await _courseRepo.IsExistedAsync(request.Title);

        if (isExisted)
        {
            return BadRequest();
        }

        item.UpdateTitle(request.Title);
        item.UpdateCredits(request.Credits);

        var result = await _courseRepo.UpdateAsync(item);

        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteStudent(Guid id)
    {
        var item = await _courseRepo.GetCourseByIdAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        await _courseRepo.RemoveAsync(item);

        return Ok();
    }
}