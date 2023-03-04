using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HRMapp2.Departments;
using HRMapp2.Projects;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace HRMapp2.Employees;

public class Employee : AuditedAggregateRoot<Guid>,IMultiTenant
{
    public Guid? TenantId { get; set; }
    public string EmployeeName { get; set; }
		
    public Guid DepartmentId { get;set; }
    public string EmployeeAddress { get; set; }
    public string EmployeeSupervisor { get; set; }
    public string EmployeeSex { get; set; }
		
    public DateTime EmployeeDob { get; set; }
    public int EmployeeWeeklyHours { get; set; }

    public ICollection<EmployeeProject> Projects { get; set; }
    public Department Department { get; set; }

    private Employee()
    {

    }
    public Employee(Guid id,string employeeName,Guid departmentId, string employeeAddress, string employeeSupervisor, string employeeSex, DateTime employeeDob, int employeeWeeklyHours, long department) : base(id)
    {
        SetName(employeeName);
        DepartmentId = departmentId;
        EmployeeAddress = employeeAddress;
        EmployeeSupervisor = employeeSupervisor;
        EmployeeSex = employeeSex;
        EmployeeDob = employeeDob;
        EmployeeWeeklyHours = employeeWeeklyHours;

        Projects = new Collection<EmployeeProject>();

    }


    //Methods:

    public void SetName([NotNull] string employeeName)
    {
        EmployeeName = Check.NotNullOrWhiteSpace(
            employeeName,
            nameof(employeeName),
            maxLength: EmployeeConsts.MaxNameLength
        );
    }
}