using InnManager.Enums;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}