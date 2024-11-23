using NUnit.Framework;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;
using System.Collections.Generic;

namespace ProjectManagementSystem.Tests
{
    [TestFixture]
    public class SearchTests
    {
        [Test]
        public void Test_Search_Tasks_Assigned_To_Employee()
        {
            // Arrange
            ITaskRepository taskRepository = new TaskRepository();
            int employeeId = 3;
            int projectId = 2;

            // Act
            List<Taskdetails> tasks = taskRepository.GetAllTasks(employeeId, projectId);

            // Assert
            Assert.That(tasks, Is.Not.Null, "Tasks list should not be null.");
            Assert.That(tasks.Count, Is.GreaterThan(0), "Tasks list should contain items.");
        }
    }
}
