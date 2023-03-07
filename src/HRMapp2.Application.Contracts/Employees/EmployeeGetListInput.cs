using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace HRMapp2.Employees;

public class EmployeeGetListInput : PagedAndSortedResultRequestDto
{
    public string queryName { get; set; }
}