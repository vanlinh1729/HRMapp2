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


namespace HRMapp2.Employees
{
	public class EmployeeRepository : EfCoreRepository<HRMapp2DbContext, Employee, Guid>, IEmployeeRepository, IRepository
	{
		public EmployeeRepository(IDbContextProvider<HRMapp2DbContext> dbContextProvider) : base(dbContextProvider)
		{

		}

		public async Task<List<EmployeeWithDetails>> GetListAsync(
			string sorting,
			int skipCount,
			int maxResultCount,
			/*string queryName,*/
			CancellationToken cancellationToken = default
		)
		{
			var query = await ApplyFilterAsync();

			return await query
				/*.WhereIf(queryName.IsNullOrWhiteSpace(), e=>e.EmployeeName.Contains(queryName))*/
				.OrderBy(!string.IsNullOrWhiteSpace(sorting) ? sorting : nameof(Employee.EmployeeName))
				.PageBy(skipCount, maxResultCount)
				.ToListAsync(GetCancellationToken(cancellationToken));
		}

		public async Task<EmployeeWithDetails> GetAsync(Guid id, CancellationToken cancellationToken = default)
		{
			var query = await ApplyFilterAsync();

			return await query
				.Where(x => x.Id == id)
				.FirstOrDefaultAsync(GetCancellationToken(cancellationToken));
		}

		private async Task<IQueryable<EmployeeWithDetails>> ApplyFilterAsync()
		{
			var dbContext = await GetDbContextAsync();

			return (await GetDbSetAsync()).Include(x=>x.Department)
				.Select(x => new EmployeeWithDetails()
				{
					Id = x.Id,
					EmployeeName = x.EmployeeName,
					DepartmentName = x.Department.DepartmentName,
					DepartmentId = x.DepartmentId,
					EmployeeAddress = x.EmployeeAddress,
					EmployeeSupervisor = x.EmployeeSupervisor,
					EmployeeSex = x.EmployeeSex,
					EmployeeDob = x.EmployeeDob,
					EmployeeWeeklyHours = x.EmployeeWeeklyHours,
					
					
				});
		}

		public override Task<IQueryable<Employee>> WithDetailsAsync()
		{
			return base.WithDetailsAsync(x => x.Projects);
		}


	}
}
