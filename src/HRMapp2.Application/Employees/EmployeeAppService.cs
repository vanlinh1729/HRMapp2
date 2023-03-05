using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HRMapp2.Departments;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HRMapp2.Employees
{
	public class EmployeeAppService :  CrudAppService<Employee,EmployeeDto, Guid,EmployeeGetListInput , CreateUpdateEmployeeDto, CreateUpdateEmployeeDto>,IEmployeeAppService
	{
		private IEmployeeRepository _repository { get; set; }
		private IRepository<Department,Guid> _repositoryDepartment { get; set; }
		
		public EmployeeAppService(IEmployeeRepository repository,IRepository<Department,Guid> repositoryDepartment) : base(repository)
		{
			_repository = repository;
			_repositoryDepartment = repositoryDepartment;
		}

		public async Task<ListResultDto<SelectDto>> GetListDepartmentAsync()
		{
			var obj = await _repositoryDepartment.GetListAsync();
			return new ListResultDto<SelectDto>( ObjectMapper.Map<List<Department>,List<SelectDto>>(obj));
		}

		/*
		public override Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
		{
			return base.GetListAsync(input);
		}
		*/

		public override async Task<PagedResultDto<EmployeeDto>> GetListAsync(EmployeeGetListInput input)
		{
			
			var employees = await _repository.GetListAsync(input.Sorting, input.SkipCount, 
				input.MaxResultCount, input.queryName);
			var totalCount = await _repository.CountAsync();

			return new PagedResultDto<EmployeeDto>(totalCount, ObjectMapper.Map<List<EmployeeWithDetails>, List<EmployeeDto>>(employees));
		}


		/*public Task<List<EmployeeWithDetails>> GetListAsync()
		{
			
		}*/
		/*public async Task<EmployeeDto> GetListEmployeeAsync()
		{
			var obj = await _repository.GetListAsync();
			
		}
		*/

	
	}
}
