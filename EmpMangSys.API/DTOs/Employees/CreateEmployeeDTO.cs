using System.ComponentModel.DataAnnotations;

namespace EmpMangSys.Api.DTOs.Employees
{
    public class CreateEmployeeDTO
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(0,double.MaxValue)]
        public decimal Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
    }
}
