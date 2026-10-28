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
        private string _firstName = "";
        /// <summary>
        /// first name property
        /// </summary>
        public string FirstName { get => _firstName; set
            {
                _firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        /// <summary>
        /// Private storage for the last name of a person.
        /// </summary>
        private string _lastName = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get => _lastName; set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        }
        /// <summary>
        /// employee position backing
        /// </summary>
        private EmployeePosition _employee = EmployeePosition.FrontDesk;
        /// <summary>
        /// employee position property
        /// </summary>
        public EmployeePosition Position { get => _employee; set
            {
                _employee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employee)));
            }
        }
        /// <summary>
        /// Indicates whether the current instance is active.
        /// </summary>
        private bool _isActive = true;
        /// <summary>
        /// is active boolean property
        /// </summary>
        public bool IsActive { get => _isActive; set
            {
                _isActive = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        /// <summary>
        /// Email backing field
        /// </summary>
        private string _email = "";
        /// <summary>
        /// The employee's email
        /// </summary>
        public string Email { get => _email; set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }
        /// <summary>
        /// Phone Number backing field
        /// </summary>
        private string _phoneNumber = "";
        /// <summary>
        /// The employee's phone number
        /// </summary>
        public string PhoneNumber { get => _phoneNumber; set
            {
                _phoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));
            }
        }
        /// <summary>
        /// Hire Date backing field
        /// </summary>
        private DateTime _hireDate = DateTime.Today;
        /// <summary>
        /// The date the employee was hired
        /// </summary>
        public DateTime HireDate { get => _hireDate; set
            {
                _hireDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HireDate)));
            }
        }
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