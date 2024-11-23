using ProjectManagementSystem.Exceptions;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;
using System;
using System.Collections.Generic;

namespace ProjectManagementSystem.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public ProjectService()
        {
            _projectRepository = new ProjectRepository();
        }

        //method to create a project
        public bool CreateProject(Project project)
        {
            if (_projectRepository.CreateProject(project))
            {
                Console.WriteLine("Project created successfully.");
                return true;
            }
            else
            {
                Console.WriteLine("Failed to create project.");
                return false;
            }
        }

        //method to delete a project
        public bool DeleteProject(int projectId)
        {
            try
            {
                bool isDeleted = _projectRepository.DeleteProject(projectId);
                if (isDeleted)
                {
                    Console.WriteLine($"Project with ID {projectId} deleted successfully.");
                }
                else
                {
                    throw new ProjectNotFoundException($"Failed to delete project with ID {projectId}. Project may not exsist");
                    //Console.WriteLine($"Failed to delete project with ID {projectId}.");
                }
                return isDeleted;
            }
            catch (Exception ex) 
            {
                    Console.WriteLine(ex.Message);
                    return false;
            }
        }

        //method to list all projects
        public void ListAllProjects()
        {
            List<Project> projects = _projectRepository.ListAllProjects();

            if (projects.Count > 0)
            {
                Console.WriteLine("\n-- List of All Projects --");
                foreach (var project in projects)
                {
                    Console.WriteLine($"Project ID: {project.Id}, Name: {project.ProjectName}, " +
                                      $"Description: {project.Description}, Start Date: {project.StartDate.ToShortDateString()}, " +
                                      $"Status: {project.Status}");
                }
            }
            else
            {
                Console.WriteLine("No projects found.");
            }
     
        }
    }
}
