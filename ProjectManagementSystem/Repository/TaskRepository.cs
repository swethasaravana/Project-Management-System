using Microsoft.Data.SqlClient;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Utility;
using System;

namespace ProjectManagementSystem.Repository
{
    public class TaskRepository : ITaskRepository
    {
        //add an task
        public bool CreateTask(Taskdetails task)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = @"INSERT INTO Task (Task_id, Task_name, Project_id, Employee_id, Status) 
                                     VALUES (@Task_id, @Task_name, @Project_id, @Employee_id, @Status)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Task_id", task.TaskId);
                    command.Parameters.AddWithValue("@Task_name", task.TaskName);
                    command.Parameters.AddWithValue("@Project_id", task.ProjectId);
                    command.Parameters.AddWithValue("@Employee_id", task.EmployeeId);
                    command.Parameters.AddWithValue("@Status", task.Status);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while creating task: {ex.Message}");
                    return false;
                }
            }
        }

        // list all Taks in a project assigned to an employeee
        public List<Taskdetails> GetAllTasks(int empId, int projectId)
        {
            var tasks = new List<Taskdetails>();

            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = @"SELECT Task_id, Task_name, Project_id, Employee_id, Status 
                                     FROM Task 
                                     WHERE Employee_id = @EmployeeId AND Project_id = @ProjectId";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@EmployeeId", empId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        tasks.Add(new Taskdetails
                        {
                            TaskId = Convert.ToInt32(reader["Task_id"]),
                            TaskName = reader["Task_name"].ToString(),
                            ProjectId = Convert.ToInt32(reader["Project_id"]),
                            EmployeeId = Convert.ToInt32(reader["Employee_id"]),
                            Status = reader["Status"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while retrieving tasks: {ex.Message}");
                }
            }

            return tasks;
        }

        //to assign task in project to employee
        public bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = @"UPDATE Task 
                             SET Employee_id = @EmployeeId 
                             WHERE Task_id = @TaskId AND Project_id = @ProjectId";

                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TaskId", taskId);
                    command.Parameters.AddWithValue("@ProjectId", projectId);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        Console.WriteLine($"DEBUG: No rows updated. Task ID: {taskId}, Project ID: {projectId}");
                    }

                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while assigning task: {ex.Message}");
                    return false;
                }
            }
        }

        //to list all tasks
        public List<Taskdetails> ListAllTasks()
        {
            var tasks = new List<Taskdetails>();

            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "SELECT Task_id, Task_name, Project_id, Employee_id, Status FROM Task";
                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tasks.Add(new Taskdetails
                            {
                                TaskId = Convert.ToInt32(reader["Task_id"]),
                                TaskName = reader["Task_name"].ToString(),
                                ProjectId = Convert.ToInt32(reader["Project_id"]),
                                EmployeeId = Convert.ToInt32(reader["Employee_id"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error while retrieving tasks: {ex.Message}");
                }
            }

            return tasks;
        }

    }
}
