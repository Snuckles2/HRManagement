using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;
using System.Collections.Generic;

namespace HRManagement.Pages.Reports
{
    public class PayrollModel : PageModel
    {
        private readonly PayrollService _payrollService;
        private readonly EmployeeService _employeeService;

        public PayrollModel(PayrollService payrollService, EmployeeService employeeService)
        {
            _payrollService = payrollService;
            _employeeService = employeeService;
        }

        public Payroll Payroll { get; set; }
        public int? EmployeeId { get; set; }
        public List<Employee> Employees { get; set; }  //add this property

        public void OnGet(int? employeeId)
        {
            Employees = _employeeService.GetEmployees();  //populate the employee list
            EmployeeId = employeeId;
            if (employeeId.HasValue)
            {
                var employee = _employeeService.GetEmployee(employeeId.Value);
                if (employee != null)
                {
                    Payroll = _payrollService.CalculatePayroll(employee);
                }
            }
        }
    }
}