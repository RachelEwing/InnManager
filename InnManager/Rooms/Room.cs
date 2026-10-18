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
        public long RoomID { get; set
            {
                RoomID = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomID)));
            }
        } = NextID;

        //The Room Number
        public string RoomNumber { get; set
            {
                RoomNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
            }
        } = "";

        //The Type of Room (Single, Double, etc.)
        public RoomType RoomType { get; set
            {
                RoomType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomType)));
            }
        } = RoomType.Standard;

        //Whether or not the room is available
        public bool IsAvailable { get; set
            {
                IsAvailable = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAvailable)));
            }
        } = true;
        //property for floor
        public int Floor
        {
            get; set
            {
                if (value > 0)
                {
                    this.Floor = value;
                    Floor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Floor)));
                }
            }
        } = 0;
        //property for capacity
        public int Capacity
        {
            get; set
            {
                if (value > 0)
                {
                    this.Capacity = value;
                    Capacity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Capacity)));
                }
            }
        } = 1;
        //property for whether or not the room has a balcony
        public bool HasBalcony { get; set
            {
                HasBalcony = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HasBalcony)));
            }
        } = false;
        //property for whether or not the room is clean
        public bool IsClean { get; set
            {
                IsClean = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsClean)));
            }
        } = true;
        //property for the status of the room
        public RoomStatus Status { get; set
            {
                Status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        } = RoomStatus.Available;

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}