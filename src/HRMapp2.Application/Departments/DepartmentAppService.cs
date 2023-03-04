using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Dtos;
using HRMapp2.Projects;
using HRMapp2.Employees;

namespace HRMapp2.Departments
{
	public class DepartmentAppService : CrudAppService<Department,DepartmentDto,Guid,PagedAndSortedResultRequestDto,CreateUpdateDepartmentDto,CreateUpdateDepartmentDto>, IDepartmentAppService
	{
		public IRepository<Department,Guid> _repository { get; set; }
		public DepartmentAppService(IRepository<Department, Guid> repository) : base(repository)
		{
			_repository = repository;
		} 
		/*
		private readonly IDepartmentRepository _departmentRepository;
		private readonly IRepository<Department,Guid> _departmentRepositorycustom;
		private readonly IRepository<Project, Guid> _projectRepository;
		private readonly IRepository<Employee, Guid> _employeeRepository;
		
		public DepartmentAppService(
		   IDepartmentRepository departmentRepository,
		   IRepository<Project, Guid> projectRepository,
		   IRepository<Employee, Guid> employeeRepository,
		   IRepository<Department,Guid> departmentRepositorycustom
	   )
		{
			_departmentRepositorycustom = departmentRepositorycustom;
			_departmentRepository = departmentRepository;
			_projectRepository = projectRepository;
			_employeeRepository = employeeRepository;
		}

		public  async Task CreateAsync(CreateUpdateDepartmentDto input)
		{
			/*var Id = new Guid();#1#
			 await _departmentRepository.InsertAsync(
			   new Department(
				   input.Id,
				   input.DepartmentName,
				   input.DepartmentManager,
				   input.ManagerStartDate,
				   input.DepartmentLocation)
				   );
		}

		public async Task DeleteAsync(Guid id)
		{
			await _departmentRepository.DeleteAsync(id);
		}

		public async Task<DepartmentDto> GetAsync(Guid id)
		{
			var department = await _departmentRepository.GetAsync(id);

			return ObjectMapper.Map<DepartmentWithDetails, DepartmentDto>(department);
		}

		public async Task<PagedResultDto<DepartmentDto>> GetListAsync(DepartmentGetListInput input)
		{
			var departments = await _departmentRepository.GetListAsync(input.Sorting, input.SkipCount, input.MaxResultCount);
			var totalCount = await _departmentRepository.CountAsync();

			return new PagedResultDto<DepartmentDto>(totalCount, ObjectMapper.Map<List<DepartmentWithDetails>, List<DepartmentDto>>(departments));
		}
		public async Task<ListResultDto<DepartmentLookupDto>> GetDepartmentLookupAsync()
		{
			var departments = await _departmentRepository.GetListAsync();

			return new ListResultDto<DepartmentLookupDto>(
				ObjectMapper.Map<List<Department>, List<DepartmentLookupDto>>(departments)
			);
		}
		
		public async Task<ListResultDto<ProjectLookupDto>> GetProjectLookupAsync()
		{
			var projects = await _projectRepository.GetListAsync();

			return new ListResultDto<ProjectLookupDto>(
				ObjectMapper.Map<List<Project>, List<ProjectLookupDto>>(projects)
			);
		}
		


		public async Task<DepartmentDto> UpdateAsync(Guid id, CreateUpdateDepartmentDto input)
		{
			input.Id = id;
			var ab = ObjectMapper.Map<CreateUpdateDepartmentDto, Department>(input);
			
			var result = await _departmentRepositorycustom.UpdateAsync(ab);
			return ObjectMapper.Map<Department, DepartmentDto>(result);

		}*/
	}
}
