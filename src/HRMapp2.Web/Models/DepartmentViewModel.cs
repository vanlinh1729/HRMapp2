using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace HRMapp2.Web.Models;

public class DepartmentViewModel
{
	
        public string DepartmentName { get; set; }
        
        public string DepartmentManager { get; set; }
		
        public DateTime ManagerStartDate { get; set; }

        public string DepartmentLocation { get; set; }
}