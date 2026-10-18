using InnManager.Employees;
using InnManager.Enums;
using System.ComponentModel;

namespace InnManager.Guests
{
    /// <summary>
    /// A class to keep track of the hotel's guests
    /// </summary>
    public class Guest : INotifyPropertyChanged
    {
        public string FirstName { get; set
            {
                FirstName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstName)));
            }
        } = "";
        /// <summary>
        /// last name property
        /// </summary>
        public string LastName { get; set
            {
                LastName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LastName)));
            }
        } = "";
        /// <summary>
        /// email property
        /// </summary>
        public string Email { get; set
            {
                Email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email)));
            }
        } = "";
        /// <summary>
        /// phone number property
        /// </summary>
        public string PhoneNumber { get; set
            {
                PhoneNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));
            }
        } = "";
        /// <summary>
        /// Checked in property
        /// </summary>
        public bool IsCheckedIn { get; set
            {
                IsCheckedIn = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedIn)));
            }
        } = false;
        /// <summary>
        /// unique ID for the guest
        /// </summary>
        public string GuestID { get; set
            {
                GuestID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestID)));
            }
        } = "";
        /// <summary>
        /// Address of the guest
        /// </summary>
        public string Address { get; set
            {
                Address = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address)));
            }
        } = "";
        /// <summary>
        /// The type of ID the guest has
        /// </summary>
        public IDType IDType { get; set
            {
                IDType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDType)));
            }
        } = IDType.Other;
        /// <summary>
        /// The ID number of the guest
        /// </summary>
        public string IDNumber { get; set
            {
                IDNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDNumber)));
            }
        } = "";

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}