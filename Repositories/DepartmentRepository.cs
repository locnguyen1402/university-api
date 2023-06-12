using UniversityApi.Data;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Repositories;

public class DepartmentRepository : BaseEntityRepository<Department>, IDepartmentRepository
{
    private readonly AppDbContext _dbContext;

    public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}