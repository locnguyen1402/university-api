using UniversityApi.Data;
using UniversityApi.Models;

namespace UniversityApi.Seeds;

public static class Seed_001
{
    public static WebApplication Seed001(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        try
        {
            dbContext.Database.EnsureCreated();

            var task = Task.Run(async () => await SeedData.Seed(dbContext));
            task.Wait();
        }
        catch (Exception)
        {

            throw;
        }

        return application;
    }
}