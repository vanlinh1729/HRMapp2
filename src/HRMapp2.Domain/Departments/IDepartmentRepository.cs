using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HRMapp2.Departments;

public interface IDepartmentRepository : IRepository<Department, Guid>
{
    Task<List<DepartmentWithDetails>> GetListAsync(
        string sorting, 
        int skipCount,
        int maxResultCount,
        CancellationToken cancellationToken = default
    );
    Task<DepartmentWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default);
    
   
}