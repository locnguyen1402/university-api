using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Data;

public class AppDbContext : BaseDbContext
{
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
    {

    }
}