using ProjectManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Service
{
    public interface IProjectService
    {
        bool CreateProject(Project project);
        bool DeleteProject(int projectId);
        void ListAllProjects();
    }
}
