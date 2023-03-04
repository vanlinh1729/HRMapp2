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
    public class ViewModal : HRMapp2PageModel
    {
        /*[HiddenInput] */
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        [BindProperty]
        public DepartmentViewModel DepartmentViewModel { get; set; }


        

        private readonly IDepartmentAppService _departmentAppService;

        public ViewModal(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public async Task OnGetAsync()
        {
            var departmentDto = await _departmentAppService.GetAsync(Id);
            DepartmentViewModel = ObjectMapper.Map<DepartmentDto, DepartmentViewModel>(departmentDto);
        }

        /*public async Task<IActionResult> OnPostAsync()
        {
           
        }*/
    
    }
    
}