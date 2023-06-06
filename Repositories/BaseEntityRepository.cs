using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;
using UniversityApi.Repositories.IRepositories;

namespace UniversityApi.Repositories;

public class BaseEntityRepository<TEntity> : IBaseEntityRepository<TEntity> where TEntity : BaseEntity
{
    private readonly BaseDbContext _dbContext;

    private readonly DbSet<TEntity> _dbSet;

    public IQueryable<TEntity> Query => _dbSet.AsNoTracking();

    public BaseEntityRepository(BaseDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async ValueTask<TEntity> AddAsync(TEntity entity)
    {
        var entityEntry = await _dbSet.AddAsync(entity);

        await SaveChangesAsync();

        return entityEntry.Entity;
    }
    public async ValueTask<TEntity> UpdateAsync(TEntity entity)
    {
        var entityEntry = _dbSet.Update(entity);

        await SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async ValueTask<TEntity?> FindAsync(object keyValues)
    {
        return await _dbSet.FindAsync(keyValues);
    }
    public async ValueTask<TEntity?> FindAsync(object[] keyValues)
    {
        return await _dbSet.FindAsync(keyValues);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _dbSet.Remove(entity);
        await SaveChangesAsync();

        // var entityEntry = _dbSet.Entry(entity);
        // entityEntry.State = EntityState.Deleted;
        // await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _dbContext.SaveChangesAsync();
    }
}