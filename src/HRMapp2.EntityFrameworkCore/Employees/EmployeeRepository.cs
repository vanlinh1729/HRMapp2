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
	public class EmployeeRepository : EfCoreRepository<HRMapp2DbContext, Employee, Guid>, IEmployeeRepository
	{
		public EmployeeRepository(IDbContextProvider<HRMapp2DbContext> dbContextProvider) : base(dbContextProvider)
		{

		}

		public async Task<List<EmployeeWithDetails>> GetListAsync(
			string sorting,
			int skipCount,
			int maxResultCount,
			string queryName,
			CancellationToken cancellationToken = default
		)
		{
			var query = await ApplyFilterAsync();

			return await query
				.WhereIf(!queryName.IsNullOrWhiteSpace(),
					e=>e.EmployeeName.ToLower().Contains(queryName.ToLower()))
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

			return (await GetDbSetAsync())
				.Include(x=>x.Department)
				.Join(dbContext.Set<Department>(),employee => employee.DepartmentId ,department => department.Id
					,(employee, department) => new {employee, department})
				.Select(x => new EmployeeWithDetails()
				{
					Id = x.employee.Id,
					EmployeeName = x.employee.EmployeeName,
					DepartmentName = x.department.DepartmentName,
					DepartmentId = x.employee.DepartmentId,
					EmployeeAddress = x.employee.EmployeeAddress,
					EmployeeSupervisor = x.employee.EmployeeSupervisor,
					EmployeeSex = x.employee.EmployeeSex,
					EmployeeDob = x.employee.EmployeeDob,
					EmployeeWeeklyHours = x.employee.EmployeeWeeklyHours,
					
					
				});
		}

		public override Task<IQueryable<Employee>> WithDetailsAsync()
		{
			return base.WithDetailsAsync(x => x.Projects);
		}


	}
}
