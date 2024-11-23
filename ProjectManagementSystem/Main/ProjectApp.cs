using System;
using System.Collections.Generic;
using System.Text;
using ProjectManagementSystem.Service;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;



namespace ProjectManagementSystem.Main
{
    class ProjectApp
    {
        static void Main(string[] args)
        {


            IEmployeeService employeeService = new EmployeeService();
            IProjectService projectService = new ProjectService();
            ITaskService taskService = new TaskService();

            while (true)
            {
                Console.WriteLine("\n=== Project Management System ===");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Add Project");
                Console.WriteLine("3. Add Task");
                Console.WriteLine("4. Assign Project to Employee");
                Console.WriteLine("5. Assign task within a project to employee");
                Console.WriteLine("6. Delete Employee");
                Console.WriteLine("7. Delete Project");
                Console.WriteLine("8. List All Tasks for an Employee in a Project");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        employeeService.CreateEmployee();
                        break;

                    case 2:
                        Console.Write("Enter Project Name: ");
                        string projectName = Console.ReadLine();

                        Console.Write("Enter Project Description: ");
                        string projectDescription = Console.ReadLine();

                        Console.Write("Enter Start Date (yyyy-mm-dd): ");
                        DateTime projectStartDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("Enter the Status of the Project: ");
                        string projectStatus = (Console.ReadLine());

                        Project newProject = new Project
                        {
                            ProjectName = projectName,
                            Description = projectDescription,
                            StartDate = projectStartDate,
                            Status = projectStatus
                        };
                        projectService.CreateProject(newProject);
                        break;

                    case 3:
                        taskService.ListAllTasks(); //list all tasks
                        Console.Write("Enter Task ID: ");
                        int taskId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Task Name: ");
                        string taskName = Console.ReadLine();
                        Console.Write("Enter Project ID: ");
                        int projectId;
                        while (!int.TryParse(Console.ReadLine(), out projectId) || projectId <= 0)
                        {
                            Console.Write("Invalid Project ID.");
                        }

                        Console.Write("Enter Employee ID: ");
                        int employeeId;
                        while (!int.TryParse(Console.ReadLine(), out employeeId) || employeeId <= 0)
                        {
                            Console.Write("Invalid Employee ID. ");
                        }

                        Console.Write("Enter Task Status: ");
                        string taskStatus = Console.ReadLine();

                        Taskdetails newTask = new Taskdetails
                        {
                            TaskName = taskName,
                            ProjectId = projectId,
                            EmployeeId = employeeId,
                            Status = taskStatus
                        };

                        taskService.CreateTask(newTask);

                        break;

                    case 4:
                        Console.WriteLine("\nListing all projects...");
                        projectService.ListAllProjects();//list all projects

                        Console.WriteLine("\nListing all employees...");
                        employeeService.GetAllEmployees();//list all employees

                        Console.Write("Enter Project ID: ");
                        int projectid = int.Parse(Console.ReadLine());

                        Console.Write("Enter Employee ID: ");
                        int employeeid = int.Parse(Console.ReadLine());

                        // Pass input to service layer
                        employeeService.AssignProjectToEmployee(projectid, employeeid);

                        break;

                    case 5:
                        Console.WriteLine("\nListing all tasks...");
                        taskService.ListAllTasks();//view all tasks

                        Console.Write("Enter Task ID: ");
                        int task_Id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Project ID: ");
                        int project_Id = int.Parse(Console.ReadLine());

                        Console.Write("Enter Employee ID: ");
                        int Employee_Id = int.Parse(Console.ReadLine());

                        taskService.AssignTaskInProjectToEmployee(task_Id, project_Id, Employee_Id);
                        break;

                    case 6:
                        employeeService.GetAllEmployees();//view all employees

                        Console.Write("Enter Employee ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int employee_Id))
                        {
                            Console.WriteLine("Invalid Employee ID.");
                            break;
                        }
                        Employee employeeToDelete = new Employee { Id = employee_Id };
                        employeeService.DeleteEmployee(employeeToDelete);
                        break;

                    case 7:
                        projectService.ListAllProjects();//view all projects

                        Console.Write("Enter Project ID to delete: ");
                        if (!int.TryParse(Console.ReadLine(), out int project_id))
                        {
                            Console.WriteLine("Invalid Project ID.");
                            break;
                        }
                        Project projectToDelete = new Project {  Id = project_id };
                        projectService.DeleteProject(project_id);
                        break;

                    case 8:
                        employeeService.GetAllEmployees();//view employees with their projectId to find the task involved

                        Console.Write("Enter Employee ID: ");
                        int empId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Project ID: ");
                        int Project_Id = int.Parse(Console.ReadLine());

                        taskService.GetAllTasks(empId, Project_Id);

                        break;

                    case 10:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
             
    }
}
//projectService.ListAllProjects();
//taskService.ListAllTasks();
//employeeService.GetAllEmployees();
