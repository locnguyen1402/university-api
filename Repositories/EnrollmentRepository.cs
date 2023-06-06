using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Repositories;

public class EnrollmentRepository : BaseEntityRepository<Enrollment>, IEnrollmentRepository
{
    private readonly AppDbContext _dbContext;

    public EnrollmentRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Enrollment?> GetEnrollment(Guid studentId, Guid courseId)
    {
        return await Query
                .AsNoTracking()
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.StudentId == studentId && s.CourseId == courseId);
    }

    public async ValueTask<Enrollment?> GetEnrollmentById(Guid id)
    {
        return await Query
                .AsNoTracking()
                .Include(s => s.Course)
                .Include(s => s.Student)
                .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async ValueTask<bool> IsExistedAsync(Guid studentId, Guid courseId)
    {
        return await Query.AnyAsync(e => e.CourseId == courseId && e.StudentId == studentId);
    }
}