using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace HRMapp2.Departments;

public class DepartmentProject : Entity<Guid>,IMultiTenant
{
    public Guid? TenantId { get; set; }
    public Guid DepartmentId { get; set; }

    public Guid ProjectId { get; set; }


    private DepartmentProject()
    {

    }

    public DepartmentProject(Guid departmentId, Guid projectId)
    {
        DepartmentId = departmentId;
        ProjectId = projectId;
    }
    public override object[] GetKeys() 
    { 
        return new object[]{ DepartmentId,ProjectId};
    }
    
}