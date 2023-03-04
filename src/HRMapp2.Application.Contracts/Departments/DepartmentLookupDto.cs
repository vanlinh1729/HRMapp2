using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HRMapp2.Departments
{
	public class DepartmentLookupDto : EntityDto<Guid>
	{
		public string DepartmentName { get; set; }
	}
}
