using AutoMapper;
using EmpMangSys.Api.DTOs.Employees;
using EmpMangSys.Core.Data;

namespace EmpMangSys.Api.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee,GetEmployeesDTO>()
                .ForMember(dest => dest.DepartmentName,
            opt => opt.MapFrom(src => src.Department.Name));

            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<UpdateDTO, Employee>();
        }
    }
}
