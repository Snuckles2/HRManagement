public class PayrollService
{
    public Payroll CalculatePayroll(Employee employee)
    {
        var payroll = new Payroll
        {
            EmployeeId = employee.Id,
            BaseSalary = employee.Salary,
            Bonus = employee.Salary * 0.1m, // 10% bonus
            Tax = employee.Salary * 0.2m // 20% tax for now
        };
        return payroll;
    }
}