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
    public class EditModal : HRMapp2PageModel
    {
        /*[HiddenInput] */
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }
        
        [BindProperty]
        public EditViewModelDepartment EditDepartment { get; set; }


        

        private readonly IDepartmentAppService _departmentAppService;

        public EditModal(IDepartmentAppService departmentAppService)
        {
            _departmentAppService = departmentAppService;
        }

        public async Task OnGetAsync()
        {
            var departmentDto = await _departmentAppService.GetAsync(Id);
            EditDepartment = ObjectMapper.Map<DepartmentDto, EditViewModelDepartment>(departmentDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ValidateModel();
            var objDepartmentDto = ObjectMapper.Map<EditViewModelDepartment, CreateUpdateDepartmentDto>(EditDepartment);
            await _departmentAppService.UpdateAsync(Id, objDepartmentDto);
            return NoContent(); 
        }
    
    }
    
}