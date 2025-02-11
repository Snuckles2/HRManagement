using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;

namespace HRManagement.Pages.Employees
{
    public class DeleteModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public DeleteModel(EmployeeService employeeService)
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
            _employeeService.DeleteEmployee(Employee.Id);
            return RedirectToPage("Index");
        }
    }
}