namespace EmpMangSys.Repository.DataBaseContext
{
    public class BadrGroupDbContext : DbContext
    {
        public BadrGroupDbContext(DbContextOptions<BadrGroupDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings here
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId);

            //seed data
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "HR", Description = "Human Resources" },
                new Department { Id = 2, Name = "IT", Description = "Information Technology" },
                new Department { Id = 3, Name = "Finance", Description = "Financial Department" }
            );
            modelBuilder.Entity<Employee>().HasData(
               new Employee { Id = 1, FullName = "Hamza Abdelkarim", PhoneNumber="01002594587",Salary=32000 ,Email ="HamzaAbdelkarim@gmail.com", HireDate = new DateTime(2023, 1, 1), DepartmentId =3},
               new Employee { Id = 2, FullName = "Laila Abdelkarim", PhoneNumber="01002003330",Salary=25000 ,Email ="LailaAbdelkarim@gmail.com", HireDate = new DateTime(2023, 1, 1), DepartmentId = 1},
               new Employee { Id = 3, FullName = "Nour Abdelkarim", PhoneNumber="01001004499",Salary=32000 ,Email ="NourAbdelkarim@gmail.com", HireDate = new DateTime(2023, 1, 1), DepartmentId = 2 },
               new Employee { Id = 4, FullName = "Jasmin Abdelkarim", PhoneNumber="01022594587",Salary=22000 ,Email ="JasminAbdelkarim@gmail.com", HireDate = new DateTime(2023, 1, 1), DepartmentId = 1 }
            );
            #region Confg 
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            //modelBuilder.ApplyConfiguration(new DepartmentConfiguration()); 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BadrGroupDbContext).Assembly);
            #endregion
        }
        
        #region Tables
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        #endregion
    }

}
