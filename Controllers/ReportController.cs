using Microsoft.AspNetCore.Mvc;
using HRManagement.Services;

namespace HRManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        private readonly PayrollService _payrollService;
        private readonly TimeTrackingService _timeTrackingService;

        public ReportController(EmployeeService employeeService, PayrollService payrollService, TimeTrackingService timeTrackingService)
        {
            _employeeService = employeeService;
            _payrollService = payrollService;
            _timeTrackingService = timeTrackingService;
        }

        [HttpGet("payroll/{employeeId}")]
        public IActionResult GetPayrollReport(int employeeId)
        {
            var employee = _employeeService.GetEmployee(employeeId);
            if (employee == null)
            {
                return NotFound();
            }
            var payroll = _payrollService.CalculatePayroll(employee);
            return Ok(payroll);
        }

        [HttpGet("time/{employeeId}")]
        public IActionResult GetTimeTrackingReport(int employeeId)
        {
            var timeEntries = _timeTrackingService.GetTimeEntries(employeeId);
            return Ok(timeEntries);
        }
    }
}