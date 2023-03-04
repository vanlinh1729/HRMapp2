using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HRMapp2.Employees;
using HRMapp2.Projects;
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
    public ICollection<Employee> Employees { get; set; }
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
        Employees = new Collection<Employee>();
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
    
    public void AddProject(Guid projectId)
    {
        Check.NotNull(projectId, nameof(projectId));

        if (IsInProject(projectId))
        {
            return;
        }

        Projects.Add(new DepartmentProject(departmentId: Id, projectId));
    }

    public void RemoveProject(Guid projectId)
    {
        Check.NotNull(projectId, nameof(projectId));

        if (!IsInProject(projectId))
        {
            return;
        }

        Projects.RemoveAll(x => x.ProjectId == projectId);
    }

    public void RemoveAllProjectsExceptGivenIds(List<Guid> projectId)
    {
        Check.NotNullOrEmpty(projectId, nameof(projectId));

        Projects.RemoveAll(x => !projectId.Contains(x.ProjectId));
    }

    public void RemoveAllProjects()
    {
        Projects.RemoveAll(x => x.DepartmentId == Id);
    }

    private bool IsInProject(Guid projectId) => Projects.Any(x => x.ProjectId == projectId);
}