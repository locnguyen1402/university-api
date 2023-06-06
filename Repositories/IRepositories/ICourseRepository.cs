using UniversityApi.Models;

namespace UniversityApi.Repositories.IRepositories;

public interface ICourseRepository : IBaseEntityRepository<Course>
{
    ValueTask<bool> IsExistedAsync(string Title);
    ValueTask<Course?> GetCourseByIdAsync(Guid id);
}