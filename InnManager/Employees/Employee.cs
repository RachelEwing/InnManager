using InnManager.Enums;
using System.ComponentModel;

namespace InnManager.Employees
{
    /// <summary>
    /// Tracks hotel employees
    /// </summary>
    public class Employee : INotifyPropertyChanged
    {
        public string EmployeeID { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EmployeeID)));
            }
        } = "";
        /// <summary>
        /// first name property
        /// </summary>
        public string FirstName { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        } = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        } = "";
        /// <summary>
        /// employee position property
        /// </summary>
        public EmployeePosition Position { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
            }
        } = EmployeePosition.FrontDesk;
        /// <summary>
        /// is active boolean property
        /// </summary>
        public bool IsActive { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        } = true;
        /// <summary>
        /// The employee's email
        /// </summary>
        public string Email { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        } = "";
        /// <summary>
        /// The employee's phone number
        /// </summary>
        public string PhoneNumber { get; set
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));
            }
        } = "";
        /// <summary>
        /// The date the employee was hired
        /// </summary>
        public DateTime HireDate { get; set
            {
                HireDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HireDate)));
            }
        } = DateTime.Today;
        /// <summary>
        /// Whether the employee is currently working
        /// </summary>
        public string Status { get { if (IsActive) return "Active"; else return "Inactive"; } }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}