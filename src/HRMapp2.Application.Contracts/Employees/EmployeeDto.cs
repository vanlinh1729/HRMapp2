﻿using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HRMapp2.Employees
{
	public class EmployeeDto : EntityDto<Guid>
	{
		public string EmployeeName { get; set; }
		
		public string DepartmentName { get; set; }
		public Guid DepartmentId { get; set; }
		public string EmployeeAddress { get; set; }
		public string EmployeeSupervisor { get; set; }
		public string EmployeeSex { get; set; }

		public DateTime EmployeeDob { get; set; }
		public int EmployeeWeeklyHours { get; set; }

		/*
		public string[] ProjectNames { get; set; }
	*/
	}
}
