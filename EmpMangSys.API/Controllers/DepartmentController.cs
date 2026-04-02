namespace EmpMangSys.Api.Controllers
{
    public class DepartmentController : ApiBaseController
    {
        private readonly IGenericRepository<Department> DepartmentRepo;
        private readonly IMapper mapper;

        public DepartmentController(IGenericRepository<Department> DepartmentRepo, IMapper mapper)
        {
            this.DepartmentRepo = DepartmentRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<GetDepartmentDTO>>> GetAll()
        {
            try
            {
                var Departments = await DepartmentRepo.GetAllAsync();
                if (Departments == null || !Departments.Any())
                    return NotFound("No Departments found.");
                var map = mapper.Map<List<GetDepartmentDTO>>(Departments);
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

        [HttpPost]
        public async Task<ActionResult<GetDepartmentDTO>> Create(CreateDepartmentDTO createDepartmentDTO)
        {
            try
            {
                var map = mapper.Map<Department>(createDepartmentDTO);
                var result = await DepartmentRepo.CreateAsync(map);
                if (result == null)
                    return BadRequest("Failed to create Department.");
                var mapResult = mapper.Map<GetDepartmentDTO>(result);
                return Ok(mapResult);
            }
            catch (Exception)
            {
                var errorMessage = new
                {
                    message = $"An error occurred while creating the Department"
                };
                return StatusCode(500, errorMessage);
            }

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetDepartmentDTO>> Update(int id, UpdateDepartmentDTO updateDepartmentDTO)
        {
            try
            {
                var existingDepartment = await DepartmentRepo.GetByIdAsync(id);
                if (existingDepartment == null)
                    return NotFound("Department not found.");
                var map = mapper.Map(updateDepartmentDTO, existingDepartment);
                var result = await DepartmentRepo.UpdateAsync(map);
                if (result == null)
                    return BadRequest("Failed to update Department.");
                var mapResult = mapper.Map<GetDepartmentDTO>(result);
                return Ok(mapResult);
            }
            catch (Exception)
            {
                var errorMessage = new
                {
                    message = $"An error occurred while updating the Department"
                };
                return StatusCode(500, errorMessage);
            }

        }
    }
}
