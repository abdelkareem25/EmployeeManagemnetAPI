using AutoMapper;
using EmpMangSys.Api.DTOs.Employees;
using EmpMangSys.Core.Data;
using EmpMangSys.Core.Interface;
using EmpMangSys.Repository.DataBaseContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmpMangSys.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IEmployeesRepository repository;

        public EmployeeController(IMapper mapper ,IEmployeesRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        //Get all
        [HttpGet]
        public ActionResult<IEnumerable<GetEmployeesDTO>> GetAll()
        {
            try
            {
                var result = repository.GetAll();
                if (result == null || !result.Any())
                {
                    return NotFound(new { message = "No employees found"});
                }
                var map= mapper.Map<IEnumerable<GetEmployeesDTO>>(result);
                return Ok(map);
            }
            catch (Exception)
            {
                var errorMessage = new
                {
                    message = $"An error occurred while retrieving employees"
                };
                return StatusCode(500, errorMessage);
            }
            
        }
        //Get by id
        [HttpGet("{id}")]
        public ActionResult<GetEmployeesDTO> GetById(int id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result == null)
                {
                    return NotFound();
                }
                var map = mapper.Map<GetEmployeesDTO>(result);
                return Ok(map);
            }
            catch (Exception)
            {

                var errorMessage = new
                {
                    message = $"No employee here have that ID"
                };
                return StatusCode(400, errorMessage);
            }
            
        }
        //Create
        [HttpPost]
        public ActionResult Create(CreateEmployeeDTO createEmployeeDto)
        {
            try
            {
                var employee = mapper.Map<Employee>(createEmployeeDto);

                repository.Create(employee);
                var result = mapper.Map<GetEmployeesDTO>(employee);

                return CreatedAtAction(nameof(GetById), new { id = employee.Id }, result);
            }
            catch (Exception)
            {
                return StatusCode(500, "Something went wrong");
            }
            
        }
        //Update
        [HttpPut("{id}")]
        public ActionResult Update(UpdateDTO dto ,int id)
        {
            var existingEmployee = repository.GetById(id); 
            if (existingEmployee == null)
            {
                return NotFound();
            }
            mapper.Map(dto, existingEmployee);
            repository.Update(existingEmployee);
            return Ok(existingEmployee);
        }
        //Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var employee = repository.GetById(id);
            if (employee == null)
                return NotFound();
            repository.Delete(id);
            return NoContent();
        }

        // Search Endpoint
        [HttpGet("search")]
        public ActionResult Search(string? name = null , string? department = null)
        {
            var result = repository.GetAll();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(e => e.FullName.Contains(name)).ToList();
            if(!string.IsNullOrEmpty(department))
                result = result.Where(e => e.Department.Name == department).ToList();
            var mapped = mapper.Map<IEnumerable<GetEmployeesDTO>>(result);
            return Ok(mapped);
        }
    }
}
