namespace EmpMangSys.Api.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        private readonly IMapper mapper;
        
        private readonly IGenericRepository<Employee> employeeRepo;

        public EmployeeController(IMapper mapper ,IGenericRepository<Employee> employeeRepo)
        {
            this.mapper = mapper;
            this.employeeRepo = employeeRepo;
        }

        //Get all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetEmployeesDTO>>> GetAll()
        {
            try
            {
                var result = await employeeRepo.GetAllAsync();
                if (result == null || !result.Any())
                     return NotFound(new { message = "No employees found"});
                
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
        public async Task<ActionResult<GetEmployeesDTO>> GetById(int id)
        {
            try
            {
                var result = await employeeRepo.GetByIdAsync(id);
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
        public async Task<ActionResult> Create(CreateEmployeeDTO createEmployeeDto)
        {
            try
            {
                var employee = mapper.Map<Employee>(createEmployeeDto);

                employeeRepo.CreateAsync(employee);
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
        public async Task<ActionResult> Update(UpdateDTO dto ,int id)
        {
            var existingEmployee = await employeeRepo.GetByIdAsync(id); 
            if (existingEmployee == null)
            {
                return NotFound();
            }
            mapper.Map(dto, existingEmployee);
            await employeeRepo.UpdateAsync(existingEmployee);
            return Ok(existingEmployee);
        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = await employeeRepo.GetByIdAsync(id);
            if (employee == null)
                return NotFound();
            await employeeRepo.DeleteAsync(id);
            return NoContent();
        }

        // Search Endpoint
        [HttpGet("search")]
        public async Task<ActionResult> Search(string? name = null , string? department = null)
        {
            var result = await employeeRepo.GetAllAsync();
            if (!string.IsNullOrEmpty(name))
                result = result.Where(e => e.FullName.Contains(name)).ToList();
            if(!string.IsNullOrEmpty(department))
                result = result.Where(e => e.Department.Name == department).ToList();
            var mapped = mapper.Map<IEnumerable<GetEmployeesDTO>>(result);
            return Ok(mapped);
        }
    }
}
