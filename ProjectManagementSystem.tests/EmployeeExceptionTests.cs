//using NUnit.Framework;
//using ProjectManagementSystem.Repository;
//using ProjectManagementSystem.Exceptions;

//namespace ProjectManagementSystem.Tests
//{
//    [TestFixture]
//    public class EmployeeExceptionTests
//    {
//        [Test]
//        public void Test_EmployeeNotFoundException_Thrown()
//        {
//            // Arrange
//            IEmployeeRepository employeeRepository = new EmployeeRepository(); // Instantiate repository
//            int nonExistentEmployeeId = 999;  // Ensure this ID does not exist in your database

//            // Act & Assert
//            var ex = Assert.Throws<EmployeeNotFoundException>(() => employeeRepository.DeleteEmployee(nonExistentEmployeeId));
//            Assert.That(ex.Message, Is.EqualTo($"Employee with ID {nonExistentEmployeeId} does not exist."));
//        }
//    }
//}


