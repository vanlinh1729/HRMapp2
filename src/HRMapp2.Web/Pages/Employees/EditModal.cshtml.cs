using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMapp2.Employees;
using HRMapp2.Projects;
using HRMapp2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMapp2.Web.Pages.Employees
{
    public class EditModal : HRMapp2PageModel
    {
        /*[HiddenInput] */
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        [BindProperty]
        public EditViewModelEmployee EditEmployee { get; set; }

        public List<SelectListItem> Departments { get; set; }

        

        private readonly IEmployeeAppService _employeeAppService;

        public EditModal(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync()
        {
            var employeeDto = await _employeeAppService.GetAsync(Id);
            var departmentDto = await _employeeAppService.GetListDepartmentAsync();
            Departments = departmentDto.Items.Select(x => new SelectListItem(x.DepartmentName, x.Id.ToString())).ToList();
            EditEmployee = ObjectMapper.Map<EmployeeDto, EditViewModelEmployee>(employeeDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            var objEmployeeDto = ObjectMapper.Map<EditViewModelEmployee, CreateUpdateEmployeeDto>(EditEmployee);
            await _employeeAppService.UpdateAsync(Id, objEmployeeDto);
            return NoContent(); 
        }
    
    }
    
}