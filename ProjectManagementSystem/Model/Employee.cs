using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem.Model
{
    public class Employee
    {
        private int _id;
        private string _name;
        private string _designation;
        private string _gender;
        private decimal _salary;
        private int _projectId;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Designation
        {
            get { return _designation; }
            set { _designation = value; }
        }

        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public decimal Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public int ProjectId
        {
            get { return _projectId; }
            set { _projectId = value; }
        }

        // Default Constructor
        public Employee() { }

        // Parameterized Constructor
        public Employee(int id, string name, string designation, string gender, decimal salary, int projectId)
        {
            _id = id;
            _name = name;
            _designation = designation;
            _gender = gender;
            _salary = salary;
            _projectId = projectId;
        }

        public override string ToString()
        {
            return $"Employee ID: {Id}, Name: {Name}, Designation: {Designation}, Gender: {Gender}, Salary: {Salary}, Project ID: {ProjectId}";
        }
    }
}
