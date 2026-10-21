using System.ComponentModel;
using System.Text;

namespace InnManager.Reservations
{
    /// <summary>
    /// Class for keeping track of hotel reservations
    /// </summary>
    public class Reservation : INotifyPropertyChanged
    {
        /// <summary>
        /// How many guests are staying the night
        /// </summary>
        public int NumberOfGuests { get; set; } = 1;
        /// <summary>
        /// The name of the guest making the reservation
        /// </summary>
        public string GuestName { get => FirstName + " " + LastName;
        }
        /// <summary>
        /// First Name of Guest
        /// </summary>
        public string FirstName { get; set; } = "";
        /// <summary>
        /// Last Name of guest
        /// </summary>
        public string LastName { get; set; } = "";
        /// <summary>
        /// The Guest's ID Number
        /// </summary>
        public string IDNumber { get; set; } = "";
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get; set;
        } = "";
        /// <summary>
        /// check in date property
        /// </summary>
        public DateTime CheckInDate { get; set;
        } = DateTime.Today;
        /// <summary>
        /// check out date property
        /// </summary>
        public DateTime CheckOutDate { get; set;
        } = DateTime.Today;
        /// <summary>
        /// checked out boolean property
        /// </summary>
        public bool IsCheckedOut { get; set;
        } = false;
        /// <summary>
        /// checked out overdue boolean property
        /// </summary>
        public bool IsCheckedOutOverdue
        {
            get
            {
                if (IsCheckedOut == false && CheckOutDate < DateTime.Today) return true;
                else return false;
            }
        }
        /// <summary>
        /// confirmation property
        /// </summary>
        public bool IsConfirmed { get; set;
        } = false;
        /// <summary>
        /// Unique number assigned to the reservation
        /// </summary>
        public string ReservationID
        {
            get
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("RES-");
                    sb.Append(LastName[0]);
                    sb.Append(LastName[1]);
                    sb.Append("-");
                    sb.Append(IDNumber.Substring(IDNumber.Length - 3));
                    sb.Append("-");
                    sb.Append(RoomNumber);
                    return sb.ToString();
                }
                catch
                {
                    return "Unavailable";
                }
            }
        }
        /// <summary>
        /// active boolean property
        /// </summary>
        public bool IsActive
        {
            get
            {
                if (IsCheckedOut == false && IsConfirmed) return true;
                else return false;
            }
        }
        /// <summary>
        /// status property
        /// </summary>
        public string Status
        {
            get
            {
                if (IsCheckedOutOverdue)
                {
                    return "Overdue";
                }
                else if (IsConfirmed)
                {
                    if (IsCheckedOut)
                    {
                        return "Checked Out";
                    }
                    else
                    {
                        return "Confirmed";
                    }
                }
                else
                {
                    return "Pending";
                }
            } set;
        }
        /// <summary>
        /// Handles property changes
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}