using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Service
{
    public interface ITaskService
    {
        void CreateTask(Taskdetails task);
        void GetAllTasks(int empId, int projectId);
        
        void ListAllTasks(); //to list all tasks
        void AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId);
    }
}
