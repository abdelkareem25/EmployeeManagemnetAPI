namespace EmpMangSys.Core.Data
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string PhoneNumber { get; set; }
        public Department Department { get; set; }
        // Foreign key
        public int DepartmentId { get; set; }

    }
}
