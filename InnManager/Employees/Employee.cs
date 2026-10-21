using InnManager.Enums;
using System.ComponentModel;
using System.Text;

namespace InnManager.Employees
{
    /// <summary>
    /// Tracks hotel employees
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        /// <summary>
        /// Unique employeeID
        /// </summary>
        public string EmployeeID { get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("EMP-");
                    sb.Append(LastName[0]);
                    sb.Append(LastName[1]);
                    return sb.ToString();
                }
                catch
                {
                    return "Unavailable";
                }
            }
        }
        /// <summary>
        /// first name property
        /// </summary>
        public string FirstName { get; set;
        } = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get; set;
        } = "";
        /// <summary>
        /// employee position property
        /// </summary>
        public EmployeePosition Position { get; set;
        } = EmployeePosition.FrontDesk;
        /// <summary>
        /// is active boolean property
        /// </summary>
        public bool IsActive { get; set;
        } = true;
        /// <summary>
        /// The employee's email
        /// </summary>
        public string Email { get; set;
        } = "";
        /// <summary>
        /// The employee's phone number
        /// </summary>
        public string PhoneNumber { get; set;
        } = "";
        /// <summary>
        /// The date the employee was hired
        /// </summary>
        public DateTime HireDate { get; set;
        } = DateTime.Today;
        /// <summary>
        /// Whether the employee is currently working
        /// </summary>
        public string Status { get { if (IsActive) return "Active"; else return "Inactive"; } }
        /// <summary>
        /// Handles property changes
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}