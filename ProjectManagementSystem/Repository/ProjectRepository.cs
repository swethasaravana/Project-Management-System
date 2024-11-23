using ProjectManagementSystem.Model;
using ProjectManagementSystem.Utility;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        //add a project
        public bool CreateProject(Project project)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = @"INSERT INTO Project (Project_name, Description, Start_Date, Status) 
                                     VALUES (@Project_name, @Description, @Start_Date, @Status)";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Project_name", project.ProjectName);
                    command.Parameters.AddWithValue("@Description", project.Description);
                    command.Parameters.AddWithValue("@Start_Date", project.StartDate);
                    command.Parameters.AddWithValue("@Status", project.Status);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while creating project: {ex.Message}");
                    return false;
                }
            }
        }

        //delete a project
        public bool DeleteProject(int projectId)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "DELETE FROM Project WHERE Project_id = @Project_id";
                    var command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Project_id", projectId);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error while deleting project: {ex.Message}");
                    return false;
                }
            }

        }

        //to list all projects
        public List<Project> ListAllProjects()
        {
            var projects = new List<Project>();

            using (var connection = DBConnUtil.GetConnection())
            {
                try
                {
                    string query = "SELECT Project_id, Project_name, Description, Start_Date, Status FROM Project";
                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            projects.Add(new Project
                            {
                                Id = Convert.ToInt32(reader["Project_id"]),
                                ProjectName = reader["Project_name"].ToString(),
                                Description = reader["Description"].ToString(),
                                StartDate = Convert.ToDateTime(reader["Start_Date"]),
                                Status = reader["Status"].ToString()
                            });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"Error while retrieving projects: {ex.Message}");
                }
            }

            return projects;
        }
    }
}
