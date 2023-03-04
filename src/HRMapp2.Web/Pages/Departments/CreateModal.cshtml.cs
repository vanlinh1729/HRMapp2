using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMapp2.Departments;
using HRMapp2.Projects;
using HRMapp2.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMapp2.Web.Pages.Departments
{
    public class CreateModal : HRMapp2PageModel
    {
        [BindProperty]
        public CreateUpdateDepartmentDto Department { get; set; }

        [BindProperty]
        public List<DepartmentViewModel> Project { get; set; }
        


        private readonly IDepartmentAppService _departmentAppService;

        public CreateModal(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public async Task OnGetAsync()
        {
            Department = new CreateUpdateDepartmentDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            await _departmentAppService.CreateAsync(Department);
            return NoContent();
        }
    }
}