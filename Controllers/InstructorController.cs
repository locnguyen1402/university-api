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
public class InstructorController : BaseController
{
    private IStudentRepository _studentRepo;
    private ICourseRepository _courseRepo;
    private IEnrollmentRepository _enrollmentRepo;
    private IInstructorRepository _instructorRepo;
    private IDepartmentRepository _departmentRepo;

    public InstructorController(
        ILogger<CourseController> logger,
        IMapper mapper,
        IStudentRepository studentRepository,
        ICourseRepository courseRepository,
        IEnrollmentRepository enrollmentRepository,
        IInstructorRepository instructorRepository,
        IDepartmentRepository departmentRepository
    ) : base(logger, mapper)
    {
        _studentRepo = studentRepository;
        _courseRepo = courseRepository;
        _enrollmentRepo = enrollmentRepository;
        _instructorRepo = instructorRepository;
        _departmentRepo = departmentRepository;
    }

    [HttpGet("{id:guid}/departments")]
    public async Task<IActionResult> GetInstructorDepartments(Guid id)
    {
        var instructor = await _instructorRepo.FindAsync(id);

        if (instructor == null)
        {
            return NotFound();
        }
        
        var query = _departmentRepo.Query.Where(s => s.InstructorID == id);

        var list = await query.ToListAsync();

        return Ok(new {
            instructor = instructor,
            departments = list
        });
    }
}