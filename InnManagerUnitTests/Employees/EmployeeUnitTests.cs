using InnManager.Employees;
using InnManager.Enums;

namespace InnManagerTests.Employees
{
    public class EmployeeUnitTests
    {
        /// <summary>
        /// Ensures employee defaults are set correctly
        /// </summary>
        [Fact]
        public void EmployeeDefaultValuesAreSetCorrectly()
        {
            Employee e = new Employee();
            Assert.Equal("", e.EmployeeID);
            Assert.Equal("", e.FirstName);
            Assert.Equal("", e.LastName);
            Assert.Equal(EmployeePosition.FrontDesk, e.Position);
            Assert.True(e.IsActive);
            Assert.Equal("", e.Email);
            Assert.Equal("", e.PhoneNumber);
            Assert.Equal(DateTime.Today, e.HireDate);
            Assert.Equal("Active", e.Status);
        }
        /// <summary>
        /// Ensures employee status is set correctly
        /// </summary>
        [Fact]
        public void EmployeeStatusIsSetCorrectly()
        {
            Employee e = new Employee();
            Assert.Equal("Active", e.Status);
            e.IsActive = false;
            Assert.Equal("Inactive", e.Status);
        }

    }
}