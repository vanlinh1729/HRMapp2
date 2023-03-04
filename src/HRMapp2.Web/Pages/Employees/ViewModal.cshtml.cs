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

namespace HRMapp2.Web.Pages.Employees
{
    public class ViewModal : HRMapp2PageModel
    {
        /*[HiddenInput] */
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        [BindProperty]
        public EmployeeViewModel EmployeeViewModel { get; set; }


        

        private readonly IEmployeeAppService _employeeAppService;

        public ViewModal(IEmployeeAppService employeeAppService)
        {
            _employeeAppService = employeeAppService;
        }

        public async Task OnGetAsync()
        {
            var employeeDto = await _employeeAppService.GetAsync(Id);
            EmployeeViewModel = ObjectMapper.Map<EmployeeDto, EmployeeViewModel>(employeeDto);
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
           
        }*/
    
    }
    
}