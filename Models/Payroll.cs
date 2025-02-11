public class Payroll
{
    public int EmployeeId { get; set; }
    public decimal BaseSalary { get; set; }
    public decimal Bonus { get; set; }
    public decimal Tax { get; set; }
    public decimal NetSalary => BaseSalary + Bonus - Tax;
}