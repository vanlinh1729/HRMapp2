using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRMapp2.Departments;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HRMapp2.Employees
{
	public interface IEmployeeAppService : 
		ICrudAppService<EmployeeDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmployeeDto, CreateUpdateEmployeeDto>, IApplicationService
	{
		Task<ListResultDto<SelectDto>> GetListDepartmentAsync();
		/*
		Task<DepartmentLookupDto> GetDepartmentLookupAsync();
		*/
	}
	
		
}
