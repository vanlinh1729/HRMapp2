using System;

namespace HRMapp2.Web.Models;

public class EditViewModelDepartment
{
    public string DepartmentName { get; set; }

    public string DepartmentManager { get; set; }
            
    public DateTime ManagerStartDate { get; set; }

    public string DepartmentLocation { get; set; }
            
}