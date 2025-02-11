using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace HRManagement.Services
{
    public class EmployeeService
    {
        private List<Employee> employees;

        public EmployeeService()
        {
            LoadEmployeesFromFile();
        }

        private void LoadEmployeesFromFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "employees.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                employees = JsonConvert.DeserializeObject<List<Employee>>(json);
            }
            else
            {
                employees = new List<Employee>();
            }
        }

        private void SaveEmployeesToFile()
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "employees.json");
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            employee.Id = employees.Count + 1;
            employees.Add(employee);
            SaveEmployeesToFile();
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (employee != null)
            {
                employee.FirstName = updatedEmployee.FirstName;
                employee.LastName = updatedEmployee.LastName;
                employee.Position = updatedEmployee.Position;
                employee.Salary = updatedEmployee.Salary;
                SaveEmployeesToFile();
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
                SaveEmployeesToFile();
            }
        }
    }
}