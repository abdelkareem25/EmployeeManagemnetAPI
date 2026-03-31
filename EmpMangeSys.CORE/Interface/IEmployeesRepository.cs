namespace EmpMangSys.Core.Interface
{
    public interface IEmployeesRepository 
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        void Create(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
