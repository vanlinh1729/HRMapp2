using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMapp2.Departments;
using HRMapp2.Employees;
using HRMapp2.Projects;
using HRMapp2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Application.Dtos;

namespace HRMapp2.Web.Pages.Employees
{
    public class CreateModal : HRMapp2PageModel
    {
        [BindProperty]
        public CreateUpdateEmployeeDto Employee { get; set; }
        public List<SelectListItem> Departments { get; set; }
        

        private readonly IEmployeeAppService _empployeeAppService;

        public CreateModal(IEmployeeAppService empployeeAppService)
        {
            _empployeeAppService = empployeeAppService;
        }

        public async Task OnGetAsync()
        {
            Employee = new CreateUpdateEmployeeDto();
            var departmentDto = await _empployeeAppService.GetListDepartmentAsync();
            Departments = departmentDto.Items.Select(x => new SelectListItem(x.DepartmentName, x.Id.ToString())).ToList();
              
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            await _empployeeAppService.CreateAsync(Employee);   
            return NoContent();
        }
    }
}