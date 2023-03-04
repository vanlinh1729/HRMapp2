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
	public class EmployeeAppService :  CrudAppService<Employee,EmployeeDto, Guid,PagedAndSortedResultRequestDto, CreateUpdateEmployeeDto, CreateUpdateEmployeeDto>,IEmployeeAppService
	{
		private IRepository<Employee,Guid> _repository { get; set; }
		private IRepository<Department,Guid> _repositoryDepartment { get; set; }
		
		public EmployeeAppService(IRepository<Employee, Guid> repository,IRepository<Department,Guid> repositoryDepartment) : base(repository)
		{
			_repository = repository;
			_repositoryDepartment = repositoryDepartment;
		}

		public async Task<ListResultDto<SelectDto>> GetListDepartmentAsync()
		{
			var obj = await _repositoryDepartment.GetListAsync();
			return new ListResultDto<SelectDto>( ObjectMapper.Map<List<Department>,List<SelectDto>>(obj));
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
