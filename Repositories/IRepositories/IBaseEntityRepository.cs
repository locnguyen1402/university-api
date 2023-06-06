using UniversityApi.Models;

namespace UniversityApi.Repositories.IRepositories;

public interface IBaseEntityRepository<TEntity> where TEntity : BaseEntity
{
    IQueryable<TEntity> Query { get; }
    ValueTask<TEntity?> FindAsync(object[] keyValues);
    ValueTask<TEntity?> FindAsync(object keyValues);
    ValueTask<TEntity> AddAsync(TEntity entity);
    ValueTask<TEntity> UpdateAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
    Task<int> SaveChangesAsync();
}