using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmpMangSys.Repository.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FullName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(e => e.Salary)
                .HasColumnType("decimal(18,2)");
           
        }
    }
}
