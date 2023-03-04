using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HRMapp2.Departments
{
	public class DepartmentDto : EntityDto<Guid>
	{
		public string DepartmentName { get; set; }

		public string DepartmentManager { get; set; }

		public DateTime ManagerStartDate { get; set; }

		public string DepartmentLocation { get; set; }
		public string[] ProjectNames { get; set; }
		/*public string[] EmployeeNames { get; set; }*/
	}
}
