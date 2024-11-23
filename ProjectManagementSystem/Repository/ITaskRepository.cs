using ProjectManagementSystem.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Repository
{
    public interface ITaskRepository
    {
        bool CreateTask(Taskdetails task);
        List<Taskdetails> GetAllTasks(int empId, int projectId);
        List<Taskdetails> ListAllTasks();
        bool AssignTaskInProjectToEmployee(int taskId, int projectId, int employeeId);

    }
}
