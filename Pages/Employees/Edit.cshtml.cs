using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;

namespace HRManagement.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public EditModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _employeeService.UpdateEmployee(Employee);
            return RedirectToPage("Index");
        }
    }
}