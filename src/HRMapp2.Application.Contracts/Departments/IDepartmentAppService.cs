using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HRMapp2.Employees;
using HRMapp2.Projects;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HRMapp2.Departments
{
	public interface IDepartmentAppService : 
		ICrudAppService<
			DepartmentDto,
			Guid,
			PagedAndSortedResultRequestDto,
			CreateUpdateDepartmentDto,
			CreateUpdateDepartmentDto>
	
		{
	
			/*Task<PagedResultDto<DepartmentDto>> GetListAsync(DepartmentGetListInput input);

			Task<DepartmentDto> GetAsync(Guid id);

			Task CreateAsync(CreateUpdateDepartmentDto input);

			Task<DepartmentDto> UpdateAsync(Guid id, CreateUpdateDepartmentDto input);

			Task DeleteAsync(Guid id);
			*/

			
	
	}
		
		


	
}
