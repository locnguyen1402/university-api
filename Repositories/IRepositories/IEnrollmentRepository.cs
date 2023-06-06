using UniversityApi.Models;

namespace UniversityApi.Repositories.IRepositories;

public interface IEnrollmentRepository : IBaseEntityRepository<Enrollment>
{
    ValueTask<Enrollment?> GetEnrollmentById(Guid id);
    ValueTask<Enrollment?> GetEnrollment(Guid studentId, Guid courseId);
    ValueTask<bool> IsExistedAsync(Guid studentId, Guid courseId);
}