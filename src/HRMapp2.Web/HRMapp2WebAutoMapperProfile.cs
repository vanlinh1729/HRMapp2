using System.Collections.Generic;
using AutoMapper;
using HRMapp2.Departments;
using HRMapp2.Employees;
using HRMapp2.Projects;
using HRMapp2.Web.Models;
using HRMapp2.Web.Pages.Departments;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AutoMapper;

namespace HRMapp2.Web
{
    public class HRMapp2WebAutoMapperProfile : Profile
    {
        public HRMapp2WebAutoMapperProfile()
        {
            CreateMap<DepartmentDto, DepartmentViewModel>();
                
    
            CreateMap<DepartmentDto, CreateUpdateDepartmentDto>();

            CreateMap<EmployeeDto, CreateUpdateEmployeeDto>();

            CreateMap<ProjectDto, CreateUpdateProjectDto>();

            CreateMap<DepartmentDto, EditViewModelDepartment>();
            CreateMap<EditViewModelDepartment, CreateUpdateDepartmentDto>();
            CreateMap<SelectDto, SelectList>();
            CreateMap<CreateUpdateEmployeeDto, Employee>();
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Employee, SelectDto>();
            CreateMap<EmployeeDto, EditViewModelEmployee>();
            CreateMap<EditViewModelEmployee, CreateUpdateEmployeeDto>();
            CreateMap<EmployeeDto, EmployeeViewModel>();


        }
    }
}