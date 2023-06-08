using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UniversityApi.Models;

namespace UniversityApi.EntityConfiguration;
public class InstructorConfiguration : BaseEntityConfiguration<Instructor>
{
    public override void Configure(EntityTypeBuilder<Instructor> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.FirstMidName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(e => e.LastName)
            .HasMaxLength(50)
            .IsRequired();
    }
}