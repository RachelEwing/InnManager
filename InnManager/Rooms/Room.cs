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
        // Keeps track of the next ID to assign to a room
        private static long _nextID = 0;
        //private field for room ID
        private long _roomID;
        //private field for room number

        //Property for updating and delivering the next room ID when a new room is added
        public static long NextID
        {
            get
            {
                _nextID++;          // Step 1: increment the ID
                return _nextID;     // Step 2: return the new value
            }
        }

        //The ID for the individual room
        public long RoomID { get; set;
        } = NextID;

        //The Room Number
        public string RoomNumber { get; set;
        } = "";

        //The Type of Room (Single, Double, etc.)
        public RoomType RoomType { get => _roomType; set
            {
                _roomType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomType)));
            }
        }

        //Whether or not the room is available
        public bool IsAvailable { get; set;
        } = true;
        //property for floor
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
        //property for capacity
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
        //property for whether or not the room has a balcony
        public bool HasBalcony { get=>_hasBalcony; set
            {
                _hasBalcony = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasBalcony)));
            }
        }
        //property for whether or not the room is clean
        public bool IsClean { get => _isClean; set
            {
                _isClean = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsClean)));
            }
        }
        //property for the status of the room
        public RoomStatus Status { get; set;
        } = RoomStatus.Available;
        /// <summary>
        /// How much the room costs per night
        /// </summary>
        public decimal Rate { get => _rate; set => _rate = value; }
        /// <summary>
        /// Handles changes in properties
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}