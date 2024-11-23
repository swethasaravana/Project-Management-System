using ProjectManagementSystem.Model;
using ProjectManagementSystem.Utility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using ProjectManagementSystem.Exceptions;

namespace ProjectManagementSystem.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        //add an employee
        public bool CreateEmployee(Employee emp)
        {
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = @"INSERT INTO Employee (Name, Designation, Gender, Salary, Project_id) 
                                    VALUES (@Name, @Designation, @Gender, @Salary, @Project_id)";
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@Name", emp.Name);
                    command.Parameters.AddWithValue("@Designation", emp.Designation);
                    command.Parameters.AddWithValue("@Gender", emp.Gender);
                    command.Parameters.AddWithValue("@Salary", emp.Salary);
                    command.Parameters.AddWithValue("@Project_id", emp.ProjectId);

                    conn.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while creating employee: {ex.Message}");
                    return false;
                }
            }
        }
        
        //delete an employee
        public bool DeleteEmployee(int empId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                string query = "DELETE FROM Employee WHERE Employee_id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", empId);
                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }

        //to assign a project to Employee
        public bool AssignProjectToEmployee(int projectId, int employeeId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = @"UPDATE Employee 
                                     SET Project_id = @ProjectId 
                                     WHERE Employee_id = @EmployeeId";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0; 
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while assigning project: {ex.Message}");
                    return false;
                }
            }
        }

        //list all employees
        public List<Employee> GetAllEmployees()
        {
            var employees = new List<Employee>();
            using (SqlConnection conn = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "SELECT * FROM Employee";
                    SqlCommand command = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            employees.Add(new Employee
                            {
                                Id = (int)reader["Employee_id"],
                                Name = (string)reader["Name"],
                                Designation = (string)reader["Designation"],
                                Gender = (string)reader["Gender"],
                                Salary = (decimal)reader["Salary"],
                                ProjectId = (int)reader["Project_id"]
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while fetching employees: {ex.Message}");
                }
            }
            return employees;
        }
    }
}


