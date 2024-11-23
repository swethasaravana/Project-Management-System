using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Taskdetails
    {
        private int _taskId;
        private string _taskName;
        private int _projectId;
        private int _employeeId;
        private string _status;

        public int TaskId
        {
            get { return _taskId; }
            set { _taskId = value; }
        }

        public string TaskName
        {
            get { return _taskName; }
            set { _taskName = value; }
        }

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        // Default Constructor
        public Taskdetails() { }

        // Parameterized Constructor
        public Taskdetails(int taskId, string taskName, int projectId, int employeeId, string status)
        {
            _taskId = taskId;
            _taskName = taskName;
            _projectId = projectId;
            _employeeId = employeeId;
            _status = status;
        }

        public override string ToString()
        {
            return $"Task ID: {TaskId}, Name: {TaskName}, Project ID: {ProjectId}, Employee ID: {EmployeeId}, Status: {Status}";
        }
    }
}
