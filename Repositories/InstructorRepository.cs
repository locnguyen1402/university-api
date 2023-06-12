using UniversityApi.Data;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Repositories;

public class InstructorRepository : BaseEntityRepository<Instructor>, IInstructorRepository
{
    private readonly AppDbContext _dbContext;

    public InstructorRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}