using BasicAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> employees;

        public EmployeeService()
        {
            employees = new List<Employee>()
            {
                new Employee(){Name="Mari", Age=22},
                new Employee(){Name="Bala", Age=25}
            };
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void RemoveEmpoyee(string name)
        {
            employees.Remove(employees.FirstOrDefault(item => item.Name == name));
        }
    }
}
