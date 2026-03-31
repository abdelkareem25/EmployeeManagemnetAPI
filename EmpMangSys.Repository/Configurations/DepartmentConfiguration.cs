using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpMangSys.Repository.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(34);
            builder.Property(d=>d.Description)
                .HasMaxLength(255);
        }
    }
}
