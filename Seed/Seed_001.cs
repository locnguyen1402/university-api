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

            var isSeedingStudent = dbContext.Students.Any();
            if (!isSeedingStudent)
            {
                var students = new Student[]
                {
                    new Student("Carson","Alexander",DateTime.Parse("2005-09-01")),
                    new Student("Meredith","Alonso",DateTime.Parse("2002-09-01")),
                    new Student("Arturo","Anand",DateTime.Parse("2003-09-01")),
                    new Student("Gytis","Barzdukas",DateTime.Parse("2002-09-01")),
                    new Student("Yan","Li",DateTime.Parse("2002-09-01")),
                    new Student("Peggy","Justice",DateTime.Parse("2001-09-01")),
                    new Student("Laura","Norman",DateTime.Parse("2003-09-01")),
                    new Student("Nino","Olivetto",DateTime.Parse("2005-09-01")),
                };

                dbContext.Students.AddRange(students);
            }

            var isSeedingCourse = dbContext.Students.Any();
            if (!isSeedingCourse)
            {
                var courses = new Course[]
                {
                    new Course("Chemistry",Credit.T3),
                    new Course("Microeconomics",Credit.T3),
                    new Course("Macroeconomics",Credit.T3),
                    new Course("Calculus",Credit.T4),
                    new Course("Trigonometry",Credit.T4),
                    new Course("Composition",Credit.T2),
                    new Course("Literature",Credit.T5)
                };

                dbContext.Courses.AddRange(courses);
            }

            dbContext.SaveChanges();
        }
        catch (Exception)
        {

            throw;
        }

        return application;
    }
}