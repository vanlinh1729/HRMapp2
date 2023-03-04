using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HRMapp2.Projects
{
	public class ProjectAppsService : 
		CrudAppService<Project,
			ProjectDto,
			Guid,
			PagedAndSortedResultRequestDto,
			CreateUpdateProjectDto,
			CreateUpdateProjectDto>, IProjectAppService
	{
		public ProjectAppsService(IRepository<Project, Guid> repository) : base(repository)
		{
		}

	
	}
}
