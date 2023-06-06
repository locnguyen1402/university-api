using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UniversityApi.Models;

namespace UniversityApi.EntityConfiguration;
public class CourseConfiguration : BaseEntityConfiguration<Course>
{
    public override void Configure(EntityTypeBuilder<Course> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Title)
            .HasMaxLength(50)
            .IsRequired();
    }
}