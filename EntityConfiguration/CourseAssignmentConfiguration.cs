using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UniversityApi.Models;

namespace UniversityApi.EntityConfiguration;
public class CourseAssignmentConfiguration : IEntityTypeConfiguration<CourseAssignment>
{
    public void Configure(EntityTypeBuilder<CourseAssignment> builder)
    {
        // builder.HasKey(e => new { e.CourseId, e.InstructorId });

        builder.HasKey("CourseId", "InstructorId");

        builder.HasOne(e => e.Instructor)
            .WithMany(e => e.CourseAssignments)
            .HasForeignKey(e => e.InstructorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.HasOne(e => e.Course)
            .WithMany(e => e.CourseAssignments)
            .HasForeignKey(e => e.CourseId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}