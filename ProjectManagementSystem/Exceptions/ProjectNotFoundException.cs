using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Exceptions
{
    internal class ProjectNotFoundException : ApplicationException
    {
        public ProjectNotFoundException()
        {
            
        }

        public ProjectNotFoundException(string message) : base(message)
        {
            
        }

    }
}
