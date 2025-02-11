using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;

namespace HRManagement.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public DetailsModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public Employee Employee { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeService.GetEmployee(id);
            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}