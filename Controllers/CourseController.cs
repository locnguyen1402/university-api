using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using UniversityApi.Controllers.Requests;
using UniversityApi.Controllers.Responses;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Controllers;
public class CourseController : BaseController
{
    private ICourseRepository _courseRepo;

    public CourseController(ILogger<CourseController> logger, IMapper mapper, ICourseRepository courseRepository) : base(logger, mapper)
    {
        _courseRepo = courseRepository;
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