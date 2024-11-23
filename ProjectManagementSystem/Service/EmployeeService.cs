using ProjectManagementSystem.Exceptions;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;
using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public bool CreateEmployee(Employee emp)
        {
            try
            {
                if (emp == null)
                {
                    throw new ArgumentNullException(nameof(emp), "Employee cannot be null.");
                }

                return _employeeRepository.CreateEmployee(emp);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while creating employee: {ex.Message}");
                return false;
            }
        }

        public void CreateEmployee()
        {
            try
            {
                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Designation: ");
                string designation = Console.ReadLine();

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                Console.Write("Enter Salary: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal salary))
                {
                    Console.WriteLine("Invalid salary input. Please enter a valid decimal number.");
                    return;
                }

                Console.Write("Enter Project ID: ");
                if (!int.TryParse(Console.ReadLine(), out int projectId))
                {
                    Console.WriteLine("Invalid Project ID. Please enter a valid integer.");
                    return;
                }

                var employee = new Employee
                {
                    Name = name,
                    Designation = designation,
                    Gender = gender,
                    Salary = salary,
                    ProjectId = projectId
                };

                if (CreateEmployee(employee))
                {
                    Console.WriteLine("Employee added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add employee.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while adding employee: {ex.Message}");
            }
        }

        //method to delete an employee
        public void DeleteEmployee(Employee employee)
        {
            try
            {
                if (_employeeRepository.DeleteEmployee(employee.Id))
                {
                    Console.WriteLine($"Employee with ID {employee.Id} deleted successfully.");
                }
                else
                {
                    throw new EmployeeNotFoundException($"Failed to delete employee with ID {employee.Id}. Employee may not exist.");
                    //Console.WriteLine($"Failed to delete employee with ID {employee.Id}.");
                }
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //method to assign a project to a employee
        public void AssignProjectToEmployee(int projectId, int employeeId)
        {
            try
            {
                bool isAssigned = _employeeRepository.AssignProjectToEmployee(projectId, employeeId);

                if (isAssigned)
                {
                    Console.WriteLine($"Project with ID {projectId} successfully assigned to Employee ID {employeeId}.");
                }
                else
                {
                    throw new EmployeeNotFoundException($"Failed to assign Project with ID {projectId} to Employee ID {employeeId}. Project or Employee might not exist.");
                    //Console.WriteLine($"Failed to assign Project with ID {projectId} to Employee ID {employeeId}. Project or Employee might not exist.");
                }
            }
            catch (EmployeeNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //method to list all employees
        public List<Employee> GetAllEmployees()
        {
            try
            {
                // Get the list of employees from the repository
                List<Employee> employees = _employeeRepository.GetAllEmployees();

                // Print the list of employees to the console
                if (employees.Count > 0)
                {
                    Console.WriteLine("\n=== Employee List ===");
                    foreach (var employee in employees)
                    {
                        Console.WriteLine($"ID: {employee.Id}, Name: {employee.Name}, Designation: {employee.Designation}, Gender: {employee.Gender}, Salary: {employee.Salary}, Project ID: {employee.ProjectId}");
                    }
                }
                else
                {
                    Console.WriteLine("No employees found.");
                }

                return employees;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while fetching employees: {ex.Message}");
                return new List<Employee>();
            }
        }

    }
}
