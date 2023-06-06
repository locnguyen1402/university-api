using UniversityApi.Models;

namespace UniversityApi.Repositories.IRepositories;

public interface IStudentRepository : IBaseEntityRepository<Student>
{
    ValueTask<Student?> GetStudentById(Guid id);
}