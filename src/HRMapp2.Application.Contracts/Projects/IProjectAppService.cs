using HRMapp2.Departments;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HRMapp2.Projects
{
	public interface IProjectAppService : ICrudAppService<ProjectDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateProjectDto,CreateUpdateProjectDto>
	{
	}
}
