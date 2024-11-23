using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Project
    {
        private int _id;
        private string _projectName;
        private string _description;
        private DateTime _startDate;
        private string _status;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string ProjectName
        {
            get { return _projectName; }
            set { _projectName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        // Default Constructor
        public Project() { }

        // Parameterized Constructor
        public Project(int id, string projectName, string description, DateTime startDate, string status)
        {
            _id = id;
            _projectName = projectName;
            _description = description;
            _startDate = startDate;
            _status = status;
        }

        public override string ToString()
        {
            return $"Project ID: {Id}, Name: {ProjectName}, Description: {Description}, Start Date: {StartDate}, Status: {Status}";
        }
    }
}
