using InnManager.Guests;
using InnManager.Rooms;
using System.ComponentModel;
using System.Reflection.Emit;
using System.Text;

namespace InnManager.Reservations
{
    /// <summary>
    /// Class for keeping track of hotel reservations
    /// </summary>
    public class Reservation : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializer, increments ID
        /// </summary>
        public Reservation() {
            _idGenerator++;
        }
        /// <summary>
        /// Room backing variable
        /// </summary>
        private Room _room;
        /// <summary>
        /// The room associated with the reservation
        /// </summary>
        public Room Room { get => _room; set {
                _room = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Room)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
            }
        }
        /// <summary>
        /// Backing field for guest
        /// </summary>
        private Guest _guest;
        /// <summary>
        /// Guest who made the reservation
        /// </summary>
        public Guest Guest { get => _guest; set {
                _guest = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Guest)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GuestName)));
            }
        }
        /// <summary>
        /// How much the reservation costs
        /// </summary>
        public decimal TotalAmount { get{
                TimeSpan difference = CheckOutDate - CheckInDate;
                int days = Math.Abs(difference.Days);
                return days * Room.Rate;
            }
        }
        /// <summary>
        /// Number of guests backing field
        /// </summary>
        private int _numberOfGuests = 1;
        /// <summary>
        /// How many guests are staying the night
        /// </summary>
        public int NumberOfGuests { get => _numberOfGuests; set
            {
                _numberOfGuests = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NumberOfGuests)));
            }
        }
        /// <summary>
        /// The name of the guest making the reservation
        /// </summary>
        public string GuestName { get => Guest.FirstName + " " + Guest.LastName;}
        /// <summary>
        /// ID number backing
        /// </summary>
        private string _iDNumber = "";
        /// <summary>
        /// The Guest's ID Number
        /// </summary>
        public string IDNumber { get => _iDNumber; set
            {
                _iDNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IDNumber)));
            }
        }
        /// <summary>
        /// room number property
        /// </summary>
        public string RoomNumber { get => Room.RoomNumber;
        }
        /// <summary>
        /// Check in date backing
        /// </summary>
        private DateTime _checkInDate = DateTime.Today;
        /// <summary>
        /// check in date property
        /// </summary>
        public DateTime CheckInDate { get => _checkInDate; set
            {
                _checkInDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckInDate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalAmount)));
            }
        }
        /// <summary>
        /// Check out Date backing
        /// </summary>
        private DateTime _checkOutDate = DateTime.Today;
        /// <summary>
        /// check out date property
        /// </summary>
        public DateTime CheckOutDate { get => _checkOutDate; set
            {
                _checkOutDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CheckOutDate)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedOutOverdue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TotalAmount)));
            }
        }
        /// <summary>
        /// Is Checked out backing
        /// </summary>
        private bool _isCheckedOut = false;
        /// <summary>
        /// checked out boolean property
        /// </summary>
        public bool IsCheckedOut { get => _isCheckedOut; set
            {
                _isCheckedOut = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedOut)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCheckedOutOverdue)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
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
        /// Is Confirmed backing field
        /// </summary>
        private bool _isConfirmed = false;
        /// <summary>
        /// confirmation property
        /// </summary>
        public bool IsConfirmed { get => _isConfirmed; set
            {
                _isConfirmed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsConfirmed)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsActive)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        /// <summary>
        /// Used to generate ID Number
        /// </summary>
        private static int _idGenerator = 1;
        /// <summary>
        /// Unique number assigned to the reservation
        /// </summary>
        private string _reservationID = ("R" + _idGenerator.ToString("D4"));
        /// <summary>
        /// unique ID for the guest
        /// </summary>
        public string ReservationID
        {
            get => _reservationID;
        }
        private bool _isCancelled = false;
        public bool IsCancelled { get => _isCancelled; set {
                _isCancelled = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCancelled)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
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
                if (IsCancelled) return "Cancelled";
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