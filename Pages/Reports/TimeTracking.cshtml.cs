using Microsoft.AspNetCore.Mvc.RazorPages;
using HRManagement.Services;
using System.Collections.Generic;

namespace HRManagement.Pages.Reports
{
    public class TimeTrackingModel : PageModel
    {
        private readonly TimeTrackingService _timeTrackingService;
        private readonly EmployeeService _employeeService;

        public TimeTrackingModel(TimeTrackingService timeTrackingService, EmployeeService employeeService)
        {
            _timeTrackingService = timeTrackingService;
            _employeeService = employeeService;
        }

        public List<TimeEntry> TimeEntries { get; set; }
        public int? EmployeeId { get; set; }

        public void OnGet(int? employeeId)
        {
            EmployeeId = employeeId;
            if (employeeId.HasValue)
            {
                TimeEntries = _timeTrackingService.GetTimeEntries(employeeId.Value).ToList();
            }
        }
    }
}