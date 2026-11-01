using InnManager.Employees;
using InnManager.Enums;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Text;

namespace InnManager.Guests
{
    /// <summary>
    /// A class to keep track of the hotel's guests
    /// </summary>
    public class Guest : INotifyPropertyChanged
    {
        public Guest() {
            _idGenerator++;
        }
        public string GuestName { get => FirstName + " " + LastName; }
        private static int _idGenerator = 1;
        private string _firstName = "";
        public string FirstName { get=>_firstName; set
            {
                _firstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        }
        private string _lastName = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get => _lastName; set
            {
                _lastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestID)));
            }
        }
        private string _email = "";
        /// <summary>
        /// email property
        /// </summary>
        public string Email { get => _email; set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        }
        private string _phoneNumber = "";
        /// <summary>
        /// phone number property
        /// </summary>
        public string PhoneNumber { get => _phoneNumber; set
            {
                _phoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));
            }
        }
        private bool _isCheckedIn = false;
        /// <summary>
        /// Checked in property
        /// </summary>
        public bool IsCheckedIn { get => _isCheckedIn; set
            {
                _isCheckedIn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedIn)));
            }
        }
        private string _guestID = ("G" + _idGenerator.ToString("D4"));
        /// <summary>
        /// unique ID for the guest
        /// </summary>
        public string GuestID { get => _guestID; }
        private string _address = "";
        /// <summary>
        /// Address of the guest
        /// </summary>
        public string Address { get => _address; set
            {
                _address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            }
        }
        private IDType _iDType = IDType.Other;
        /// <summary>
        /// The type of ID the guest has
        /// </summary>
        public IDType IDType { get => _iDType; set
            {
                _iDType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDType)));
            }
        }
        private string _iDNumber = "";
        /// <summary>
        /// The ID number of the guest
        /// </summary>
        public string IDNumber { get=>_iDNumber; set
            {
                _iDNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDNumber)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestID)));
            }
        }
        /// <summary>
        /// Handles property changes
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}