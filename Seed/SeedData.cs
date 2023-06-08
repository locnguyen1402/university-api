using Microsoft.EntityFrameworkCore;
using UniversityApi.Data;
using UniversityApi.Models;

namespace UniversityApi.Seeds;

public class SeedData
{
    public async static Task Seed(AppDbContext dbContext)
    {
        await InitStudents(dbContext);
        await InitInstructors(dbContext);
        await InitDepartments(dbContext);
        await InitCourses(dbContext);
        await InitCourseAssignments(dbContext);
        await InitEnrollments(dbContext);
    }

    private async static Task InitEntities<TEntity>(AppDbContext dbContext, TEntity[] items) where TEntity : class
    {
        var dbSet = dbContext.Set<TEntity>();

        var isSeeding = await dbSet.AnyAsync();
        if (!isSeeding)
        {
            dbSet.AddRange(items);
            await dbContext.SaveChangesAsync();
        }
    }

    private async static Task InitStudents(AppDbContext dbContext)
    {
        var items = new Student[]
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

        await InitEntities(dbContext, items);
    }

    private async static Task InitInstructors(AppDbContext dbContext)
    {
        var items = new Instructor[] {
            new Instructor ( FirstMidName: "Kim", LastName: "Abercrombie", HireDate: DateTime.Parse("1995-03-11") ),
            new Instructor ( FirstMidName : "Fadi", LastName : "Fakhouri", HireDate : DateTime.Parse("2002-07-06") ),
            new Instructor ( FirstMidName : "Roger", LastName: "Harui", HireDate : DateTime.Parse("1998-07-01") ),
            new Instructor ( FirstMidName : "Candace", LastName : "Kapoor", HireDate : DateTime.Parse("2001-01-15") ),
            new Instructor ( FirstMidName : "Roger",   LastName : "Zheng", HireDate : DateTime.Parse("2004-02-12") ),
            new Instructor ( FirstMidName : "Loc",   LastName : "Nguyen" ),
        };

        await InitEntities(dbContext, items);
    }

    private async static Task InitDepartments(AppDbContext dbContext)
    {
        var items = new Department[]
        {
            new Department("English",
                            instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Abercrombie"))?.Id ),
            new Department("Mathematics",
                            instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Fakhouri"))?.Id ),
            new Department("Engineering",
                            instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Harui"))?.Id ),
            new Department("Economics",
                            instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Kapoor"))?.Id ),
        };

        await InitEntities(dbContext, items);
    }

    private async static Task InitCourses(AppDbContext dbContext)
    {
        var items = new Course[]
        {
            new Course("Chemistry",Credit.T3,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "Engineering"))?.Id ),
            new Course("Microeconomics",Credit.T3,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "Economics"))?.Id ),
            new Course("Macroeconomics",Credit.T3,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "Economics"))?.Id ),
            new Course("Calculus",Credit.T4,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "Mathematics"))?.Id ),
            new Course("Trigonometry",Credit.T4,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "Mathematics"))?.Id ),
            new Course("Composition",Credit.T2,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "English"))?.Id ),
            new Course("Literature",Credit.T5,
                        DepartmentId: (await dbContext.Departments.FirstOrDefaultAsync(s => s.Name == "English"))?.Id )
        };

        await InitEntities(dbContext, items);
    }

    private async static Task InitCourseAssignments(AppDbContext dbContext)
    {
        var items = new CourseAssignment[] {
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Kapoor"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Chemistry" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Harui"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Chemistry" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Zheng"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Microeconomics" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Zheng"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Macroeconomics" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Fakhouri"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Calculus" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Harui"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Trigonometry" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Abercrombie"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Composition" ))!.Id
            ),
            new CourseAssignment (
                instructorId: (await dbContext.Instructors.FirstOrDefaultAsync(s => s.LastName == "Abercrombie"))!.Id ,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Literature" ))!.Id
            ),
        };

        await InitEntities(dbContext, items);
    }

    private async static Task InitEnrollments(AppDbContext dbContext)
    {
        var items = new Enrollment[] {
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Alexander" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Chemistry" ))!.Id,
                grade: Grade.A
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Alexander" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Microeconomics" ))!.Id,
                grade: Grade.B
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Alexander" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Macroeconomics" ))!.Id,
                grade: Grade.C
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Alonso" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Calculus" ))!.Id,
                grade: Grade.D
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Alonso" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Trigonometry" ))!.Id,
                grade: Grade.F
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Alonso" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Composition" ))!.Id,
                grade: Grade.C
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Anand" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Chemistry" ))!.Id,
                grade: Grade.D
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Anand" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Microeconomics" ))!.Id,
                grade: Grade.B
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Barzdukas" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Chemistry" ))!.Id,
                grade: Grade.F
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Li" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Composition" ))!.Id,
                grade: Grade.A
            ),
            new Enrollment(
                studentId: (await dbContext.Students.FirstOrDefaultAsync(s => s.LastName == "Justice" ))!.Id,
                courseId: (await dbContext.Courses.FirstOrDefaultAsync(s => s.Title == "Literature" ))!.Id,
                grade: Grade.C
            ),
        };

        await InitEntities(dbContext, items);
    }
}