using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Repositories;

public class CourseRepository : BaseEntityRepository<Course>, ICourseRepository
{
    private readonly AppDbContext _dbContext;

    public CourseRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Course?> GetCourseByIdAsync(Guid id)
    {
        return await Query
                        .AsNoTracking()
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Student)
                        .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async ValueTask<bool> IsExistedAsync(string Title)
    {
        return await Query.AnyAsync(c => c.Title == Title);
    }
}