using Microsoft.EntityFrameworkCore.Metadata.Builders;

using UniversityApi.Models;

namespace UniversityApi.EntityConfiguration;
public class DepartmentConfiguration : BaseEntityConfiguration<Department>
{
    public override void Configure(EntityTypeBuilder<Department> builder)
    {
        base.Configure(builder);

        builder.Property(e => e.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(e => e.Administrator)
            .WithMany();
    }
}