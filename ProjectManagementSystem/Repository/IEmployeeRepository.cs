using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Repository
{
    public interface IEmployeeRepository
    {
        bool CreateEmployee(Employee emp);
        bool DeleteEmployee(int employeeId);
        bool AssignProjectToEmployee(int projectId, int employeeId);
        List<Employee> GetAllEmployees();
    }
}
