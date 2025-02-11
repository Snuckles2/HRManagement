using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;

namespace HRManagement.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public CreateModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
        public Employee Employee { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeService.AddEmployee(Employee);
            return RedirectToPage("Index");
        }
    }
}