using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;
using System.Collections.Generic;

namespace HRManagement.Pages.Employees
{
    public class IndexModel : PageModel
    {
        private readonly EmployeeService _employeeService;

        public IndexModel(EmployeeService employeeService)
        {
            _employeeService = employeeService;
            Employees = new List<Employee>(); // Initialize the property
        }

        public List<Employee> Employees { get; set; }

        public void OnGet()
        {
            Employees = _employeeService.GetEmployees();
        }
    }
}