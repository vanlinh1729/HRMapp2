using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace HRMapp2.Departments;

public class DepartmentEmployee : Entity<Guid>,IMultiTenant
{
    public Guid? TenantId { get; set; }
    public Guid DepartmentId { get; set; }

    public Guid EmployeeId { get; set; }


    private DepartmentEmployee()
    {

    }

    public DepartmentEmployee(Guid departmentId, Guid employeeId)
    {
        DepartmentId = departmentId;
        EmployeeId = employeeId;
    }
    public override object[] GetKeys() 
    { 
        return new object[]{ DepartmentId,EmployeeId};
    }
    
}