using System;
using Volo.Abp.Domain.Entities;

namespace HRMapp2.Employees;

public class EmployeeProject : Entity<Guid>
{
    public Guid ProjectId { get; set; }
		
    public Guid EmployeeId { get; set; }

    private EmployeeProject()
    {

    }

    public EmployeeProject(Guid projectId, Guid employeeId)
    {
        ProjectId = projectId;
        EmployeeId = employeeId;
    }
    public override object[] GetKeys()
    {
        return new object[] { ProjectId, EmployeeId };
    }

    
}