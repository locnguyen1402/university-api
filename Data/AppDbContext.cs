using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Data;

public class AppDbContext : BaseDbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Instructor> Instructors => Set<Instructor>();
    public DbSet<CourseAssignment> CourseAssignments => Set<CourseAssignment>();
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {

    }
}