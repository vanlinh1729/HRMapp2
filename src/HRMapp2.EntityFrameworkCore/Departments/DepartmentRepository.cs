using HRMapp2.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRMapp2.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using HRMapp2.Departments;
using HRMapp2.Employees;
using HRMapp2.Projects;
using System.Threading;
using System.Linq.Dynamic.Core;
using Volo.Abp.Domain.Repositories;


namespace HRMapp2.Departments
{
	public class DepartmentRepository : EfCoreRepository<HRMapp2DbContext, Department, Guid>, IDepartmentRepository, IRepository
	{
		public DepartmentRepository(IDbContextProvider<HRMapp2DbContext> dbContextProvider) : base(dbContextProvider)
		{

		}

		public async Task<List<DepartmentWithDetails>> GetListAsync(
			string sorting,
			int skipCount,
			int maxResultCount,
			CancellationToken cancellationToken = default
		)
		{
			var query = await ApplyFilterAsync();

			return await query
				.OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(Department.DepartmentName))
				.PageBy(skipCount, maxResultCount)
				.ToListAsync(GetCancellationToken(cancellationToken));
		}

		public async Task<DepartmentWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var query = await ApplyFilterAsync();

			return await query
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
		}

		private async Task<IQueryable<DepartmentWithDetails>> ApplyFilterAsync()
		{
			var dbContext = await GetDbContextAsync();

			return (await GetDbSetAsync())
				.Include(x=>x.Employees)
				.Select(x => new DepartmentWithDetails()
				{
					Id = x.Id,
					DepartmentName = x.DepartmentName,
					DepartmentManager = x.DepartmentManager,
					DepartmentLocation = x.DepartmentLocation,
					ManagerStartDate = x.ManagerStartDate,
					CreationTime = x.CreationTime,
					EmployeeNames = (from departmentEmployee in x.Employees
						join employee in dbContext.Set<Employee>() on departmentEmployee.DepartmentId equals employee.Id
						select employee.EmployeeName).ToArray()
					
				});
		}

		public override Task<IQueryable<Department>> WithDetailsAsync()
		{
			return base.WithDetailsAsync(x => x.Employees);
		}


	}
}
