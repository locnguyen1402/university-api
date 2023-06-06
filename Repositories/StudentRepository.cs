using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Repositories;

public class StudentRepository : BaseEntityRepository<Student>, IStudentRepository
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async ValueTask<Student?> GetStudentById(Guid id)
    {
        return await Query
                        .AsNoTracking()
                        .Include(s => s.Enrollments)
                            .ThenInclude(e => e.Course)
                        .FirstOrDefaultAsync(s => s.Id == id);
    }
}