using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HRMapp2.Employees;

public interface IEmployeeRepository : IRepository<Employee, Guid>
{
    Task<List<EmployeeWithDetails>> GetListAsync(
        string sorting,
        int skipCount,
        int maxResultCount,
        CancellationToken cancellationToken = default
    );

    Task<EmployeeWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
}