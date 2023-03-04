using System;
using System.Threading.Tasks;
using HRMapp2.Departments;
using HRMapp2.Projects;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace HRMapp2;

public class HRMapp2DataSeederContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IGuidGenerator _guidGenerator;
    private readonly IRepository<Project, Guid> _projectRepository;
    private readonly IRepository<Department, Guid> _departmentRepository;

    public HRMapp2DataSeederContributor(
        IGuidGenerator guidGenerator,
        IRepository<Project, Guid> projectRepository,
        IRepository<Department, Guid> departmentRepository)
    {
        _guidGenerator = guidGenerator;
        _projectRepository = projectRepository;
        _departmentRepository = departmentRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        
        await SeedProjectsAsync();
        
        await SeedDepartmentsAsync();
    }

    private async Task SeedProjectsAsync()
    {
        if (await _projectRepository.GetCountAsync() <= 0)
        {
            await _projectRepository.InsertAsync(
                new Project(_guidGenerator.Create(), "Project 1", "HP")
            );

            await _projectRepository.InsertAsync(
                new Project(_guidGenerator.Create(), "Project 2", "VN")
            );

            await _projectRepository.InsertAsync(
                new Project(_guidGenerator.Create(), "Project 3", "HN")
            );
        }
    }

    private async Task SeedDepartmentsAsync()
    {
        if (await _departmentRepository.GetCountAsync() <= 0)
        {
            await _departmentRepository.InsertAsync(
                new Department(
                    _guidGenerator.Create(),
                    "Department 3",
                    "Manager 3",
                    new DateTime(2023, 02, 01),
                    "Sencond floor."
                )
            );

            await _departmentRepository.InsertAsync(
                new Department(
                    _guidGenerator.Create(),
                    "Department 4",
                    "Manager 4",
                    new DateTime(2023, 03, 01),
                    "Third floor."
                )
            );
        }
    }
}
    
