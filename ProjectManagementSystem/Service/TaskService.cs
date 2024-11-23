using ProjectManagementSystem.Exceptions;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService()
        {
            _taskRepository = new TaskRepository();
        }

        //method to add an employee
        public void CreateTask(Taskdetails task)
        {
            if (_taskRepository.CreateTask(task))
            {
                Console.WriteLine("Task created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create task.");
            }
        }

        //method to list all Taks in a project assigned to an employeee 
        public void GetAllTasks(int empId, int projectId)
        {
            List<Taskdetails> tasks = _taskRepository.GetAllTasks(empId, projectId);

            if (tasks.Count > 0)
            {
                Console.WriteLine($"Tasks for Employee ID: {empId} in Project ID: {projectId}:");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Task ID: {task.TaskId}, Task Name: {task.TaskName}, Status: {task.Status}");
                }
            }
            else
            {
                Console.WriteLine("No tasks found for the given employee and project.");
            }
        }

        //method to assign task in project to employee
        public void AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId)
        {
            try
            {
                bool isAssigned = _taskRepository.AssignTaskInProjectToEmployee(taskId, projectId, employeeId);

                if (isAssigned)
                {
                    Console.WriteLine($"Task with ID {taskId} in Project ID {projectId} successfully assigned to Employee ID {employeeId}.");
                }
                else
                {
                    throw new ProjectNotFoundException($"Failed to assign Task with ID {taskId} in Project ID {projectId} to Employee ID {employeeId}. Task or Project might not exist.");
                    //Console.WriteLine($"Failed to assign Task with ID {taskId} in Project ID {projectId} to Employee ID {employeeId}. Task or Project might not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message );
            }
        }

        //method to list all tasks
        public void ListAllTasks()
        {
            List<Taskdetails> tasks = _taskRepository.ListAllTasks();

            if (tasks.Count > 0)
            {
                Console.WriteLine("\n=== List of All Tasks ===");
                foreach (var task in tasks)
                {
                    Console.WriteLine($"Task ID: {task.TaskId}, Name: {task.TaskName}, " +
                                      $"Project ID: {task.ProjectId}, Employee ID: {task.EmployeeId}, Status: {task.Status}");
                }
            }
            else
            {
                Console.WriteLine("No tasks found.");
            }
        }
    }
}
