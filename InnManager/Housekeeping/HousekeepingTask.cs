using InnManager.Enums;
using System.ComponentModel;
using InnManager.Employees;
using InnManager.Rooms;

namespace InnManager.Housekeeping
{
    /// <summary>
    /// A class for keeping track of housekeeping tasks
    /// </summary>
    public class HousekeepingTask : INotifyPropertyChanged
    {
        private Room _room;
        public Room Room { get => _room; set {
                _room = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Room)));
            }
        }       
        /// <summary>
        /// Employee backing variable
        /// </summary>
        private Employee _employee;
        /// <summary>
        /// The employee assigned to do the task
        /// </summary>
        public Employee Employee { get => _employee; set {
                _employee = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Employee)));
            }
        }
        /// <summary>
        /// Private field storing the room number.
        /// </summary>
        private string _roomNumber = "";
        /// <summary>
        /// RoomNumber of room the task is associated with
        /// </summary>
        public string RoomNumber { get => _roomNumber; set
            {
                _roomNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoomNumber)));
            }
        }
        /// <summary>
        /// Description backing field
        /// </summary>
        private string _description = "";
        /// <summary>
        /// description of task property
        /// </summary>
        public string Description { get => _description; set
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }
        /// <summary>
        /// Scheduled Time Backing field
        /// </summary>
        private DateTime _scheduledDate = DateTime.Today;
        /// <summary>
        /// scheduled date for task property
        /// </summary>
        public DateTime ScheduledDate { get => _scheduledDate; set
            {
                _scheduledDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ScheduledDate)));
            }
        }
        /// <summary>
        /// Is completed backing field
        /// </summary>
        private bool _isCompleted = false;
        /// <summary>
        /// is completed boolean property
        /// </summary>
        public bool IsCompleted { get => _isCompleted; set
            {
                _isCompleted = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsCompleted)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        /// <summary>
        /// Assigned staff backing field
        /// </summary>
        private string _assignedStaff = "";
        /// <summary>
        /// Staff assigned to the task
        /// </summary>
        public string AssignedStaff { get => _assignedStaff; set
            {
                _assignedStaff = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AssignedStaff)));
            }
        }
        /// <summary>
        /// status property
        /// </summary>
        public string Status
        {
            get
            {
                if (IsCompleted)
                {
                    return "Complete";
                }
                else
                {
                    return "Not Completed";
                }
            }
        }
        /// <summary>
        /// Handles changes in properties
        /// </summary>

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}