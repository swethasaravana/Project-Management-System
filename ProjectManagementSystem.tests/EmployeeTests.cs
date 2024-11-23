using NUnit.Framework;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;

namespace ProjectManagementSystem.Tests
{
    [TestFixture]
    public class EmployeeTests
    {
        [Test]
        public void Test_Employee_Created_Successfully()
        {
            // Arrange
            IEmployeeRepository employeeRepository = new EmployeeRepository();
            Employee employee = new Employee
            {
                Name = "John Doe",
                Designation = "Developer",
                Gender = "M",
                Salary = 60000,
                ProjectId = 1
            };

            // Act
            bool isCreated = employeeRepository.CreateEmployee(employee);

            // Assert
            Assert.That(isCreated, Is.True, "Employee should be created successfully.");
        }
    }
}
