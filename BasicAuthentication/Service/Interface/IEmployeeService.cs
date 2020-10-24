using BasicAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAuthentication
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees();

        void AddEmployee(Employee employee);

        void RemoveEmpoyee(string name);
    }
}
