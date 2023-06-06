using Microsoft.EntityFrameworkCore;

namespace UniversityApi.Data;

public abstract class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions opts) : base(opts)
    {

    }
}