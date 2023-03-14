using AutoMapper;
using HRMapp2.Departments;
using HRMapp2.Employees;
using HRMapp2.Projects;

namespace HRMapp2;

public class HRMapp2ApplicationAutoMapperProfile : Profile
{
    public HRMapp2ApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        
        CreateMap<Department, DepartmentDto>();
        CreateMap<DepartmentWithDetails, DepartmentDto>();
        CreateMap<Project, ProjectDto>();
        CreateMap<Employee, EmployeeDto>();

        CreateMap<Project, ProjectLookupDto>();
        CreateMap<CreateUpdateProjectDto, Project>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
        CreateMap<CreateUpdateDepartmentDto, Department>();
        

        CreateMap<DepartmentWithDetails, DepartmentDto>();
        CreateMap<Department, SelectDto>();
        CreateMap<Employee, SelectDto>();
        CreateMap<EmployeeWithDetails, EmployeeDto>();
        CreateMap<Employee, GetEmployeeDto>();

    }
}
