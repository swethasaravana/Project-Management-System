using NUnit.Framework;
using ProjectManagementSystem.Model;
using ProjectManagementSystem.Repository;

namespace ProjectManagementSystem.Tests
{
    [TestFixture]
    public class TaskTests
    {
        [Test]
        public void Test_Task_Created_Successfully()
        {
            // Arrange
            ITaskRepository taskRepository = new TaskRepository();
            Taskdetails task = new Taskdetails
            {
                TaskName = "Develop API",
                ProjectId = 1,
                EmployeeId = 3,
                Status = "assigned"
            };

            // Act
            bool isCreated = taskRepository.CreateTask(task);

            // Assert
            Assert.That(isCreated, Is.True, "Task should be created successfully.");
        }
    }
}
