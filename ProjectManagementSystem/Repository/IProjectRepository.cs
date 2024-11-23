using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Repository
{
    public interface IProjectRepository
    {
        bool CreateProject(Project project);
        bool DeleteProject(int projectId);
        List<Project> ListAllProjects();


    }
}
