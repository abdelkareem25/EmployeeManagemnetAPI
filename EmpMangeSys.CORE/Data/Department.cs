namespace EmpMangSys.Core.Data
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>(); //NullReferenceException
    }
}
