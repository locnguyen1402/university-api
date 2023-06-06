using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityApi.Models;

namespace UniversityApi.EntityConfiguration;
public class EnrollmentConfiguration : BaseEntityConfiguration<Enrollment>
{
    public override void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        base.Configure(builder);

        builder.HasAlternateKey(e => new { e.CourseId, e.StudentId });

        builder.HasOne(e => e.Student)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.StudentId)
            .IsRequired();

        builder.HasOne(e => e.Course)
            .WithMany(e => e.Enrollments)
            .HasForeignKey(e => e.CourseId)
            .IsRequired();
    }
}