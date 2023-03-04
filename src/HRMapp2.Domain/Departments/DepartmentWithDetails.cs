using System;
using Volo.Abp.Auditing;

namespace HRMapp2.Departments;

public class DepartmentWithDetails : IHasCreationTime
{
    public Guid Id { get; set; }
    public string DepartmentName { get; set; }

    public string DepartmentManager { get; set; }

    public DateTime ManagerStartDate { get; set; }

    public string DepartmentLocation { get; set; }
    public string[] EmployeeNames {get;set;}
    public string[] ProjectNames { get; set; }
    public DateTime CreationTime {get;set;}
}