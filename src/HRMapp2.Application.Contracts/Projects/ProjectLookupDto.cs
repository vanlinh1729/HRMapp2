using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HRMapp2.Projects
{
	public class ProjectLookupDto : EntityDto<Guid>
	{
		public string ProjectName { get; set; }
	}
}
