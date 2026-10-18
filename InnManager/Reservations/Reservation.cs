using System.ComponentModel;

namespace InnManager.Reservations
{
    /// <summary>
    /// Class for keeping track of hotel reservations
    /// </summary>
    public class Reservation : INotifyPropertyChanged
    {
        public string GuestName { get; set
            {
                GuestName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestName)));
            }
        } = "";
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get; set
            {
                RoomNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
            }
        } = "";
        /// <summary>
        /// check in date property
        /// </summary>
        public DateTime CheckInDate { get; set
            {
                CheckInDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckInDate)));
            }
        } = DateTime.Today;
        /// <summary>
        /// check out date property
        /// </summary>
        public DateTime CheckOutDate { get; set
            {
                CheckOutDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckOutDate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedOutOverdue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        } = DateTime.Today;
        /// <summary>
        /// checked out boolean property
        /// </summary>
        public bool IsCheckedOut { get; set
            {
                IsCheckedOut = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedOut)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedOutOverdue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
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
        public bool IsConfirmed { get; set
            {
                IsConfirmed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsConfirmed)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        } = false;
        /// <summary>
        /// Unique number assigned to the reservation
        /// </summary>
        public string ReservationNumber { get; set
            {
                ReservationNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReservationNumber)));
            }
        } = "";
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
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}