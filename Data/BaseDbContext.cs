using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace UniversityApi.Data;

public abstract class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opts) : base(opts)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}