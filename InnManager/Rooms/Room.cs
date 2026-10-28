using InnManager.Enums;
using System.ComponentModel;

namespace InnManager.Rooms
{
    /// <summary>
    /// Represents a hotel room managed by the InnManager system.
    /// </summary>
    /// <remarks>
    /// The Room class stores identifying information about a hotel room, including its room number, room type, nightly rate and current availability.
    /// </remarks>
    public class Room : INotifyPropertyChanged
    {
        /// <summary>
        /// Backing field for cleanliness
        /// </summary>
        private bool _isClean = true;
        /// <summary>
        /// Backing field for balcony bool
        /// </summary>
        private bool _hasBalcony = false;
        /// <summary>
        /// Backing field for room's rate
        /// </summary>
        private decimal _rate = 0;
        /// <summary>
        /// backing field for roomtype
        /// </summary>
        private RoomType _roomType = RoomType.Standard;
        /// <summary>
        /// Private backing field for capacity
        /// </summary>
        private int _capacity = 1;
        /// <summary>
        /// private backing field for floor
        /// </summary>
        private int _floor = 0;
        /// <summary>
        /// Keeps track of the next ID to assign to a room
        /// </summary>
        private static long _nextID = 0;
        /// <summary>
        /// private field for room ID
        /// </summary>
        private long _roomID;

        /// <summary>
        /// Property for updating and delivering the next room ID when a new room is added
        /// </summary>
        public static long NextID
        {
            get
            {
                _nextID++;          // Step 1: increment the ID
                return _nextID;     // Step 2: return the new value
            }
        }

        /// <summary>
        /// The ID for the individual room
        /// </summary>
        public long RoomID { get; set;
        } = NextID;
        /// <summary>
        /// Backing field for room number
        /// </summary>
        private string _roomNumber = "";
        /// <summary>
        /// The Room Number
        /// </summary>
        public string RoomNumber { get => _roomNumber; set
            {
                _roomNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
            }
        }

        /// <summary>
        /// The Type of Room (Single, Double, etc.)
        /// </summary>
        public RoomType RoomType { get => _roomType; set
            {
                _roomType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomType)));
            }
        }
        /// <summary>
        /// Backing field for is available
        /// </summary>
        private bool _isAvailable = true;

        /// <summary>
        /// Whether or not the room is available
        /// </summary>
        public bool IsAvailable { get => _isAvailable; set
            {
                _isAvailable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAvailable)));
            }
        }
        /// <summary>
        /// property for floor
        /// </summary>
        public int Floor
        {
            get => _floor; set
            {
                if (value > 0)
                {
                    _floor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Floor)));
                }
            }
        }
        /// <summary>
        /// property for capacity
        /// </summary>
        public int Capacity
        {
            get => _capacity; set
            {
                if (value > 0)
                {
                    _capacity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Capacity)));
                }
            }
        }
        /// <summary>
        /// property for whether or not the room has a balcony
        /// </summary>
        public bool HasBalcony { get=>_hasBalcony; set
            {
                _hasBalcony = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasBalcony)));
            }
        }
        /// <summary>
        /// property for whether or not the room is clean
        /// </summary>
        public bool IsClean { get => _isClean; set
            {
                _isClean = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsClean)));
            }
        }
        /// <summary>
        /// Backing field for Status
        /// </summary>
        private RoomStatus _status = RoomStatus.Available;
        /// <summary>
        /// property for the status of the room
        /// </summary>
        public RoomStatus Status { get => _status; set
            {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        /// <summary>
        /// How much the room costs per night
        /// </summary>
        public decimal Rate { get => _rate; set {
                _rate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Rate)));
            } }
        /// <summary>
        /// Handles changes in properties
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}