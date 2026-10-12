using InnManager.Enums;

namespace InnManager.Employees
{
    /// <summary>
    /// Tracks hotel employees
    /// </summary>
    public class Employee
    {
        public string EmployeeID { get; set; } = "";
        /// <summary>
        /// first name property
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get; set; } = "";
        /// <summary>
        /// employee position property
        /// </summary>
        public EmployeePosition Position { get; set; } = EmployeePosition.FrontDesk;
        /// <summary>
        /// is active boolean property
        /// </summary>
        public bool IsActive { get; set; } = true;
        /// <summary>
        /// The employee's email
        /// </summary>
        public string Email { get; set; } = "";
        /// <summary>
        /// The employee's phone number
        /// </summary>
        public string PhoneNumber { get; set; } = "";
        /// <summary>
        /// The date the employee was hired
        /// </summary>
        public DateTime HireDate { get; set; } = DateTime.Today;
        /// <summary>
        /// Whether the employee is currently working
        /// </summary>
        public string Status { get { if (IsActive) return "Active"; else return "Inactive"; } }
    }
}