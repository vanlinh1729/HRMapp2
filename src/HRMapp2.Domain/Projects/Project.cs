using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HRMapp2.Departments;
using HRMapp2.Employees;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace HRMapp2.Projects;

public class Project : AuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public string ProjectName { get; set; }

    public string ProjectLocation { get; set; }

    public ICollection<DepartmentProject> Departments { get; set; }
    public ICollection<EmployeeProject> Employees { get; set; }
    private Project()
    {

    }
    public Project(Guid id,string projectName, string projectLocation) : base(id)
    {
        SetName(projectName);
        ProjectLocation = projectLocation;

        Departments = new Collection<DepartmentProject>();
        Employees = new Collection<EmployeeProject>();
    }
    public void SetName([NotNull] string projectName)
    {
        ProjectName = Check.NotNullOrWhiteSpace(
            projectName,
            nameof(projectName),
            ProjectConsts.MaxNameLength
        );
    }
}