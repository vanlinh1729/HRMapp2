using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using HRMapp2.Departments;
using JetBrains.Annotations;
using HRMapp2.Employees;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;

public class DepartmentManager : DomainService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IRepository<Employee, Guid> _employeeRepository;

    public DepartmentManager(IDepartmentRepository departmentRepository, IRepository<Employee, Guid> employeeRepository)
    {
        _departmentRepository = departmentRepository;
        _employeeRepository =  employeeRepository;
    }

    public async Task CreateAsync(Guid id, [NotNull] string departmentName,[CanBeNull] string departmentManager,[CanBeNull] DateTime managerStartDate,[CanBeNull] string departmentLocation,
        [CanBeNull] string[] employeeNames)
    {
        var department = new Department(GuidGenerator.Create(), departmentName, departmentManager, managerStartDate, departmentLocation);

        await SetEmployeesAsync(department, employeeNames);

        await _departmentRepository.InsertAsync(department);
    }

    public async Task UpdateAsync(
        Department department,
        string departmentName,
        [CanBeNull]string departmentManager,
        [CanBeNull]DateTime managerStartDate,
        [CanBeNull]string departmentLocation,
        [CanBeNull] string[] employeeNames
    )
    {
        department.SetName(departmentName);
        department.DepartmentManager = departmentManager;
        department.ManagerStartDate = managerStartDate;
        department.DepartmentLocation = departmentLocation;

        await SetEmployeesAsync(department, employeeNames);

        await _departmentRepository.UpdateAsync(department);
    }

    private async Task SetEmployeesAsync(Department department, [CanBeNull] string[] employeeNames)
    {
        if (employeeNames == null || !employeeNames.Any())
        {
            department.RemoveAllEmployees();
            return;
        }

        var query = (await _employeeRepository.GetQueryableAsync())
            .Where(x => employeeNames.Contains(x.EmployeeName))
            .Select(x => x.Id)
            .Distinct();

        var employeeIds = await AsyncExecuter.ToListAsync(query);
        if (!employeeIds.Any())
        {
            return;
        }

        department.RemoveAllEmployeesExceptGivenIds(employeeIds);

        foreach (var employeeId in employeeIds)
        {
            department.AddEmployee(employeeId);
        }
    }
}