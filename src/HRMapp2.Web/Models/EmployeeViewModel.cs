using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HRMapp2.Web.Models;

public class EmployeeViewModel
{
	
	public string EmployeeName { get; set; }
	public string DepartmentName { get; set; }
	public string EmployeeAddress { get; set; }
	public string EmployeeSupervisor { get; set; }
	public string EmployeeSex { get; set; }

	public DateTime EmployeeDob { get; set; }
	public int EmployeeWeeklyHours { get; set; }
}