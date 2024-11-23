using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Service
{
    public interface IEmployeeService
    {
        bool CreateEmployee(Employee emp);
        void CreateEmployee();
        void DeleteEmployee(Employee employee);
        void AssignProjectToEmployee(int projectId, int employeeId);
        List<Employee> GetAllEmployees();//to get all employees
    }
}
