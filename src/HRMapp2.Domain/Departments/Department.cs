using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HRMapp2.Employees;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace HRMapp2.Departments;

public class Department : AuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public string DepartmentName { get; set; }
    public string DepartmentManager { get; set; }
		
    public DateTime ManagerStartDate { get; set; }
	
    public string DepartmentLocation { get; set; }
    public ICollection<DepartmentProject> Projects { get; set; }
    public ICollection<DepartmentEmployee> Employees { get; set; }
    private Department()
    {

    }
    public Department(Guid id, [NotNull] string departmentName,[CanBeNull] string departmentManager,[CanBeNull] DateTime managerStartDate,[CanBeNull] string departmentLocation) : base(id)
    {
        SetName(departmentName);
        DepartmentManager = departmentManager;
        ManagerStartDate = managerStartDate;
        DepartmentLocation = departmentLocation;

        Projects = new Collection<DepartmentProject>();
        Employees = new Collection<DepartmentEmployee>();
    }

    //Methods:

    public void SetName([NotNull] string departmentName) 
    { 
        DepartmentName = Check.NotNullOrWhiteSpace(
            departmentName,
            nameof(departmentName), 
            maxLength: DepartmentConsts.MaxNameLength
        );
    }
    
    public void AddEmployee(Guid employeeId)
    {
        Check.NotNull(employeeId, nameof(employeeId));

        if (IsInEmployee(employeeId))
        {
            return;
        }

        Employees.Add(new DepartmentEmployee(departmentId: Id, employeeId));
    }

    public void RemoveEmployee(Guid employeeId)
    {
        Check.NotNull(employeeId, nameof(employeeId));

        if (!IsInEmployee(employeeId))
        {
            return;
        }

        Employees.RemoveAll(x => x.EmployeeId == employeeId);
    }

    public void RemoveAllEmployeesExceptGivenIds(List<Guid> employeeIds)
    {
        Check.NotNullOrEmpty(employeeIds, nameof(employeeIds));

        Employees.RemoveAll(x => !employeeIds.Contains(x.EmployeeId));
    }

    public void RemoveAllEmployees()
    {
        Employees.RemoveAll(x => x.DepartmentId == Id);
    }

    private bool IsInEmployee(Guid employeeId) => Employees.Any(x => x.EmployeeId == employeeId);
}